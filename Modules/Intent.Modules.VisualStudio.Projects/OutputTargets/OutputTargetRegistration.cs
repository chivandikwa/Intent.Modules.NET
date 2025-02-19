﻿using Intent.Engine;
using Intent.Modules.VisualStudio.Projects.Api;
using Intent.Registrations;

namespace Intent.Modules.VisualStudio.Projects.OutputTargets
{
    public class OutputTargetRegistration : IOutputTargetRegistration
    {
        private readonly IMetadataManager _metadataManager;

        public OutputTargetRegistration(IMetadataManager metadataManager)
        {
            _metadataManager = metadataManager;
        }

        public void Register(IOutputTargetRegistry registry, IApplication application)
        {
            var models = _metadataManager.GetAllProjectModels(application);
            foreach (var model in models)
            {
                registry.RegisterOutputTarget(model.ToOutputTargetConfig());
                foreach (var folder in model.Folders)
                {
                    Register(registry, folder);
                }
            }

            var solutionFolders = _metadataManager.VisualStudio(application).GetSolutionFolderModels();
            foreach (var solutionFolder in solutionFolders)
            {
                registry.RegisterOutputTarget(solutionFolder.ToOutputTarget());
            }
        }

        private static void Register(IOutputTargetRegistry registry, FolderModel folder)
        {
            registry.RegisterOutputTarget(folder.ToOutputTargetConfig());
            foreach (var child in folder.Folders)
            {
                Register(registry, child);
            }
        }
    }
}
