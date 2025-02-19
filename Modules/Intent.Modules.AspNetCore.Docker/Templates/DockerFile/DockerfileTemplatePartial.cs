﻿using System.Collections.Generic;
using Intent.Modules.Common.Plugins;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.VisualStudio;
using Intent.Modules.Constants;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Configuration;
using Intent.Modules.Common.CSharp.VisualStudio;
using Intent.Templates;
using Intent.Utils;

namespace Intent.Modules.AspNetCore.Docker.Templates.DockerFile
{
    partial class DockerfileTemplate : IntentFileTemplateBase<object>, ITemplate, IHasNugetDependencies, ITemplateBeforeExecutionHook
    {
        public const string Identifier = "Intent.AspNetCore.Dockerfile";

        private string _defaultLaunchUrlPath;


        public DockerfileTemplate(IProject project)
            : base(Identifier, project, null)
        {
            ExecutionContext.EventDispatcher.Subscribe<DefaultLaunchUrlPathRequest>(Handle);
        }

        private void Handle(DefaultLaunchUrlPathRequest request)
        {
            _defaultLaunchUrlPath = request.UrlPath;
        }


        public IEnumerable<INugetPackageInfo> GetNugetDependencies()
        {
            yield return NugetPackages.MicrosoftVisualStudioAzureContainersToolsTargets;
        }

        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TemplateFileConfig(
                overwriteBehaviour: OverwriteBehaviour.OnceOff,
                codeGenType: CodeGenType.Basic,
                fileName: "Dockerfile",
                fileExtension: "",
                relativeLocation: ""
                );
        }

        public override void BeforeTemplateExecution()
        {
            ExecutionContext.EventDispatcher.Publish(LaunchProfileRegistrationEvent.EventId, new Dictionary<string, string>()
            {
                { LaunchProfileRegistrationEvent.ProfileNameKey, "Docker" },
                { LaunchProfileRegistrationEvent.CommandNameKey, "Docker" },
                { LaunchProfileRegistrationEvent.LaunchBrowserKey, "true" },
                { LaunchProfileRegistrationEvent.LaunchUrlKey, $"{{Scheme}}://{{ServiceHost}}:{{ServicePort}}{AddDefaultLaunchUrl()}" },
                { LaunchProfileRegistrationEvent.PublishAllPorts, "true" },
                { LaunchProfileRegistrationEvent.UseSSL, "true" },
            });
        }

        private string AddDefaultLaunchUrl()
        {
            if (string.IsNullOrWhiteSpace(_defaultLaunchUrlPath))
            {
                return string.Empty;
            }

            return $"/{_defaultLaunchUrlPath}";
        }

        private string GetRuntime()
        {
            if (Project.IsNetCore2App())
            {
                return "mcr.microsoft.com/dotnet/aspnet:2.1";
            }
            if (Project.IsNetCore3App())
            {
                return "mcr.microsoft.com/dotnet/aspnet:3.1";
            }
            if (Project.IsNetApp(5))
            {
                return "mcr.microsoft.com/dotnet/aspnet:5.0";
            }
            if (Project.IsNetApp(6))
            {
                return "mcr.microsoft.com/dotnet/aspnet:6.0";
            }

            if (Project.IsNetApp(7))
            {
                return "mcr.microsoft.com/dotnet/aspnet:7.0";
            }

            Logging.Log.Warning(@"Project .NET version not supported by this Docker module. You may need to edit your docker file manually.");
            return "mcr.microsoft.com/dotnet/aspnet:6.0";
        }

        private string GetSdk()
        {
            if (Project.IsNetCore2App())
            {
                return "mcr.microsoft.com/dotnet/sdk:2.1";
            }
            if (Project.IsNetCore3App())
            {
                return "mcr.microsoft.com/dotnet/sdk:3.1";
            }
            if (Project.IsNetApp(5))
            {
                return "mcr.microsoft.com/dotnet/sdk:5.0";
            }
            if (Project.IsNetApp(6))
            {
                return "mcr.microsoft.com/dotnet/sdk:6.0";
            }
            if (Project.IsNetApp(7))
            {
                return "mcr.microsoft.com/dotnet/sdk:7.0";
            }

            return "mcr.microsoft.com/dotnet/sdk:6.0";
        }
    }
}
