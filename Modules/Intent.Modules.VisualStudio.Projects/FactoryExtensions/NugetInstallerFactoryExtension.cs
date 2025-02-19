using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Intent.Engine;
using Intent.Eventing;
using Intent.Modules.Common;
using Intent.Modules.Common.Plugins;
using Intent.Modules.Constants;
using Intent.Modules.VisualStudio.Projects.Events;
using Intent.Modules.VisualStudio.Projects.NuGet.HelperTypes;
using Intent.Modules.VisualStudio.Projects.NuGet.SchemeProcessors;
using Intent.Modules.VisualStudio.Projects.Templates;
using Intent.Plugins.FactoryExtensions;
using Intent.Utils;
using NuGet.Versioning;

namespace Intent.Modules.VisualStudio.Projects.NuGet
{
    public class NugetInstallerFactoryExtension : FactoryExtensionBase, IExecutionLifeCycle
    {
        private readonly ISoftwareFactoryEventDispatcher _sfEventDispatcher;
        private readonly IChanges _changeManager;
        public const string Identifier = "Intent.VisualStudio.NuGet.Installer";
        private const string SettingKeyForConsolidatePackageVersions = "Consolidate Package Versions"; // Must match the config entry in the .imodspec
        private const string SettingKeyForWarnOnMultipleVersionsOfSamePackage = "Warn On Multiple Versions of Same Package"; // Must match the config entry in the .imodspec
        private bool _settingConsolidatePackageVersions;
        private bool _settingWarnOnMultipleVersionsOfSamePackage;
        private readonly IDictionary<string, IVisualStudioProjectTemplate> _projectRegistry = new Dictionary<string, IVisualStudioProjectTemplate>();
        private static readonly IDictionary<VisualStudioProjectScheme, INuGetSchemeProcessor> NuGetProjectSchemeProcessors;

        static NugetInstallerFactoryExtension()
        {
            NuGetProjectSchemeProcessors = new Dictionary<VisualStudioProjectScheme, INuGetSchemeProcessor>
            {
                { VisualStudioProjectScheme.Lean, new LeanSchemeProcessor() },
                { VisualStudioProjectScheme.Unsupported, new UnsupportedSchemeProcessor() },
                { VisualStudioProjectScheme.VerboseWithPackageReference, new VerboseWithPackageReferencesSchemeProcessor() },
                { VisualStudioProjectScheme.VerboseWithPackagesDotConfig, new VerboseWithPackagesDotConfigSchemeProcessor() }
            };
        }

        public NugetInstallerFactoryExtension(ISoftwareFactoryEventDispatcher sfEventDispatcher, IChanges changeManager)
        {
            _sfEventDispatcher = sfEventDispatcher;
            _changeManager = changeManager;

        }

        public override int Order => 200;

        public override string Id => Identifier;

        public override void Configure(IDictionary<string, string> settings)
        {
            settings.SetIfSupplied(
                name: SettingKeyForConsolidatePackageVersions,
                setSetting: parsedValue => _settingConsolidatePackageVersions = parsedValue,
                convert: rawValue => true.ToString().Equals(rawValue, StringComparison.OrdinalIgnoreCase));
            settings.SetIfSupplied(
                name: SettingKeyForWarnOnMultipleVersionsOfSamePackage,
                setSetting: parsedValue => _settingWarnOnMultipleVersionsOfSamePackage = parsedValue,
                convert: rawValue => true.ToString().Equals(rawValue, StringComparison.OrdinalIgnoreCase));

            base.Configure(settings);
        }

        protected override void OnBeforeTemplateRegistrations(IApplication application)
        {
            application.EventDispatcher.Subscribe<VisualStudioProjectCreatedEvent>(HandleEvent);
            base.OnBeforeTemplateRegistrations(application);
        }

        protected override void OnAfterTemplateExecution(IApplication application)
        {
            var tracing = new TracingWithPrefix(Logging.Log, "NuGet - ");

            tracing.Info("Start processing packages");

            // Call a separate method to do the actual execution which is internally accessible and more easily unit testable.
            Execute(
                applicationProjects: _projectRegistry.Values,
                tracing: tracing,
                saveProjectDelegate: SaveProject);

            tracing.Info("Package processing complete");
            base.OnAfterTemplateExecution(application);
        }

        private void HandleEvent(VisualStudioProjectCreatedEvent @event)
        {
            if (_projectRegistry.ContainsKey(@event.TemplateInstance.ProjectId))
            {
                throw new Exception($"Attempted to add project with same project Id [{@event.TemplateInstance.ProjectId}] (location: {@event.TemplateInstance.FilePath})");
            }
            _projectRegistry.Add(@event.TemplateInstance.ProjectId, @event.TemplateInstance);
        }

        private void SaveProject(string filePath, string content)
        {
            var change = _changeManager.FindChange(filePath);

            // Normalize the content of both by parsing with no whitespace and calling .ToString()
            var targetContent = XDocument.Parse(content).ToString();
            var existingContent = change != null
                ? XDocument.Parse(change.Content).ToString()
                : XDocument.Load(filePath).ToString();

            if (existingContent == targetContent)
            {
                return;
            }

            if (change != null)
            {
                change.ChangeContent(content);
                return;
            }

            _sfEventDispatcher.Publish(new SoftwareFactoryEvent(SoftwareFactoryEvents.OverwriteFileCommand, new Dictionary<string, string>
            {
                { "FullFileName", filePath },
                { "Content", content },
            }));
        }

        /// <param name="saveProjectDelegate">T1 = path, T2 = content</param>
        internal void Execute(
            IEnumerable<IVisualStudioProjectTemplate> applicationProjects,
            ITracing tracing,
            Action<string, string> saveProjectDelegate)
        {
            string report;
            var (projectPackages, highestVersions) = DeterminePackages(applicationProjects);

            if (_settingConsolidatePackageVersions &&
                !string.IsNullOrWhiteSpace(report = GetPackagesWithMultipleVersionsReport(projectPackages)))
            {
                tracing.Info(
                    "Multiple versions exist for one or more NuGet packages within the solution. Intent will now automatically " +
                           "upgrade any lower versions to the highest installed version within the solution. To disable this behaviour " +
                           $"change the 'Consolidate Package Versions' option in Intent in the {Identifier} module configuration." +
                           $"{Environment.NewLine}" +
                           $"{Environment.NewLine}" +
                           $"{report}");

                ConsolidatePackageVersions(projectPackages, highestVersions);
            }

            foreach (var projectPackage in projectPackages)
            {
                if (!projectPackage.RequestedPackages.Any())
                {
                    continue;
                }

                var updatedProjectContent = projectPackage.Processor.InstallPackages(
                    projectContent: projectPackage.Content,
                    requestedPackages: projectPackage.RequestedPackages,
                    installedPackages: projectPackage.InstalledPackages,
                    projectName: projectPackage.Name,
                    tracing: tracing);
                saveProjectDelegate(projectPackage.FilePath, updatedProjectContent);
            }

            if (_settingWarnOnMultipleVersionsOfSamePackage &&
                !_settingConsolidatePackageVersions &&
                !string.IsNullOrWhiteSpace(report = GetPackagesWithMultipleVersionsReport(projectPackages)))
            {
                tracing.Warning(
                    "Multiple versions exist for one or more NuGet packages within the solution. You should consider " +
                           "consolidating these package versions within Visual Studio or alternatively enable the 'Consolidate " +
                           $"Package Versions' option in Intent in the {Identifier} module configuration." +
                           $"{Environment.NewLine}" +
                           $"{Environment.NewLine}" +
                           $"{report}");
            }

        }

        /// <summary>
        /// Internal so available to unit tests
        /// </summary>
        internal static (IReadOnlyCollection<NuGetProject> Projects, Dictionary<string, VersionRange> HighestVersions) DeterminePackages(IEnumerable<IVisualStudioProjectTemplate> applicationProjects)
        {
            var projects = new List<NuGetProject>();

            var highestVersions = new Dictionary<string, VersionRange>();
            foreach (var project in applicationProjects.OrderBy(x => x.Name))
            {
                var projectNugetInfo = DetermineProjectNugetPackageInfo(project);
                foreach (var nuGetVersion in projectNugetInfo.HighestVersions)
                {
                    if (!highestVersions.TryGetValue(nuGetVersion.Key, out var highestVersion) ||
                        (highestVersion != null &&
                         highestVersion.MinVersion < nuGetVersion.Value.MinVersion))
                    {
                        highestVersions[nuGetVersion.Key] = nuGetVersion.Value;
                    }
                }
                projects.Add(projectNugetInfo);
            }

            return (projects, highestVersions);
        }

        internal static NuGetProject DetermineProjectNugetPackageInfo(IVisualStudioProjectTemplate project)
        {
            var projectContent = project.LoadContent();
            var document = XDocument.Parse(projectContent);

            var projectType = document.ResolveProjectScheme();
            if (!NuGetProjectSchemeProcessors.TryGetValue(projectType, out var processor))
                throw new ArgumentOutOfRangeException(nameof(projectType), $"No scheme registered for type {projectType}.");

            //if (!_projectRegistry.ContainsKey(project.Model.Id))
            //{
            //    Logging.Log.Warning($"Project file not found for project [{project}]");
            //    continue;
            //}
            var installedPackages = processor.GetInstalledPackages(project.FilePath, document);

            var highestVersionsInProject = new Dictionary<string, VersionRange>();
            foreach (var installedPackage in installedPackages)
            {
                var packageId = installedPackage.Key;

                if (!highestVersionsInProject.TryGetValue(packageId, out var highestVersion) ||
                    highestVersion.MinVersion < installedPackage.Value.Version.MinVersion)
                {
                    highestVersionsInProject[packageId] = installedPackage.Value.Version;
                }
            }

            //var consolidatedPackages = installedPackages.ToDictionary(x => x.Key, x => x.Value.Clone());
            var requestedPackages = new Dictionary<string, NuGetPackage>();

            foreach (var package in project.RequestedNugetPackages())
            {
                if (!VersionRange.TryParse(package.Version, out var semanticVersion))
                {
                    throw new Exception(
                        $"Could not parse '{package.Version}' from Intent metadata for package '{package.Name}' in project '{project.Name}' as a valid Semantic Version 2.0 'version' value.");
                }

                if (!highestVersionsInProject.TryGetValue(package.Name, out var highestVersion) ||
                    (highestVersion != null &&
                     highestVersion.MinVersion < semanticVersion.MinVersion))
                {
                    highestVersionsInProject[package.Name] = highestVersion = semanticVersion;
                }

                //if (consolidatedPackages.TryGetValue(package.Name, out var consolidatedPackage))
                //{
                //    consolidatedPackage.Update(highestVersion, package);
                //}
                //else
                //{
                //    consolidatedPackages.Add(package.Name, NuGetPackage.Create(package, highestVersion));
                //}

                if (requestedPackages.TryGetValue(package.Name, out var requestedPackage))
                {
                    requestedPackage.Update(highestVersion, package);
                }
                else
                {
                    requestedPackages.Add(package.Name, NuGetPackage.Create(project.FilePath, package, highestVersion));
                }
            }

            return new NuGetProject
            {
                Content = projectContent,
                RequestedPackages = requestedPackages,
                InstalledPackages = installedPackages,
                HighestVersions = highestVersionsInProject,
                Name = project.Name,
                FilePath = project.FilePath,
                Processor = processor
            };
        }

        private static void ConsolidatePackageVersions(IReadOnlyCollection<NuGetProject> projectPackages, IDictionary<string, VersionRange> highestVersions)
        {
            foreach (var highestVersion in highestVersions)
            {
                foreach (var projectPackage in projectPackages)
                {
                    if (projectPackage.RequestedPackages.TryGetValue(highestVersion.Key, out var requestedPackage) &&
                        requestedPackage.Version.MinVersion < highestVersion.Value.MinVersion)
                    {
                        requestedPackage.Version = highestVersion.Value;
                        continue;
                    }

                    if (projectPackage.InstalledPackages.TryGetValue(highestVersion.Key, out var installedPackage) &&
                        installedPackage.Version.MinVersion < highestVersion.Value.MinVersion)
                    {
                        projectPackage.RequestedPackages.Add(highestVersion.Key, installedPackage.Clone(highestVersion.Value));
                    }
                }
            }
        }

        private static string GetPackagesWithMultipleVersionsReport(IEnumerable<NuGetProject> nuGetProjects)
        {
            var resolvedProjects = nuGetProjects
                .Select(x => new
                {
                    ConsolidatedPackageVersions = x.GetConsolidatedPackages(),
                    ProjectName = x.Name
                })
                .ToArray();

            var packagesWithMultipleVersions = resolvedProjects
                .SelectMany(x => x.ConsolidatedPackageVersions)
                .GroupBy(x => x.Key, x => x.Value.Version)
                .Where(x => x.Distinct().Count() > 1)
                .Select(x => x.Key)
                .ToArray();

            if (!packagesWithMultipleVersions.Any())
            {
                return null;
            }

            return packagesWithMultipleVersions
                .Select(packageId => new
                {
                    PackageId = packageId,
                    VersionReport = resolvedProjects
                        .Where(x => x.ConsolidatedPackageVersions.ContainsKey(packageId))
                        .Select(x => new
                        {
                            x.ProjectName,
                            x.ConsolidatedPackageVersions[packageId].Version
                        })
                        .OrderByDescending(x => x.Version.ToString())
                        .ThenBy(x => x.ProjectName)
                        .Select(x => $"    Version {x.Version} in '{x.ProjectName}'")
                        .Aggregate((x, y) => x + Environment.NewLine + y)
                })
                .Select(x => $"{x.PackageId} has the following versions installed:{Environment.NewLine}{x.VersionReport}")
                .Aggregate((x, y) => x + Environment.NewLine + y);
        }
    }

    internal static class VsProjectExtensions
    {
        internal static VisualStudioProjectScheme ResolveProjectScheme(this XDocument xNode)
        {
            if (xNode == null)
            {
                return VisualStudioProjectScheme.Unsupported;
            }

            var (prefix, namespaceManager, _) = xNode.Document.GetNamespaceManager();

            if (xNode.XPathSelectElement($"/{prefix}:Project[@Sdk]", namespaceManager) != null)
            {
                return VisualStudioProjectScheme.Lean;
            }

            if (xNode.XPathSelectElement($"/{prefix}:Project/{prefix}:ItemGroup/{prefix}:None[@Include='packages.config']", namespaceManager) != null)
            {
                return VisualStudioProjectScheme.VerboseWithPackagesDotConfig;
            }

            if (xNode.XPathSelectElement($"/{prefix}:Project", namespaceManager) != null)
            {
                // Even if there is no PackageReference element, so long as there is no packages.config, then we are free to to use
                // PackageReferences going forward. In the event there is PackageReference element, then we are of course already
                // using the PackageReference scheme.
                return VisualStudioProjectScheme.VerboseWithPackageReference;
            }

            return VisualStudioProjectScheme.Unsupported;
        }

        internal static string ToFormattedProjectString(this XDocument document)
        {
            // Changes the XML from:

            // <Project Sdk="Microsoft.NET.Sdk">
            //   <PropertyGroup>
            //     ...
            //   </PropertyGroup>
            //   <PropertyGroup>
            //     ...
            //   </PropertyGroup>
            // </Project>

            // To:

            // <Project Sdk="Microsoft.NET.Sdk">
            //
            //   <PropertyGroup>
            //     ...
            //   </PropertyGroup>
            //
            //   <PropertyGroup>
            //     ...
            //   </PropertyGroup>
            //
            // </Project>

            if (document.ResolveProjectScheme() != VisualStudioProjectScheme.Lean)
            {
                return document.ToString();
            }

            document = XDocument.Parse(document.ToString(), LoadOptions.PreserveWhitespace);
            if (document == null)
                throw new Exception("document is null");
            if (document.Root == null)
                throw new Exception("document.Root is null");

            foreach (var node in document.Root.Nodes())
            {
                if (node is XText xText)
                {
                    xText.Value = $"\n{xText.Value}";
                }
            }

            return document.ToString();
        }
    }
}
