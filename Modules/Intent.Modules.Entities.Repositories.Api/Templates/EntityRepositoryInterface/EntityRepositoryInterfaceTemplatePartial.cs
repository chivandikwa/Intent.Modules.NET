﻿using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Modelers.Domain.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.VisualStudio;
using Intent.Modules.Entities.Repositories.Api.Templates.RepositoryInterface;
using Intent.Templates;

namespace Intent.Modules.Entities.Repositories.Api.Templates.EntityRepositoryInterface
{
    partial class EntityRepositoryInterfaceTemplate : CSharpTemplateBase<ClassModel>, ITemplate, IHasTemplateDependencies, ITemplatePostCreationHook
    {
        public const string TemplateId = "Intent.Entities.Repositories.Api.EntityInterface";
        public const string Identifier = TemplateId;

        public EntityRepositoryInterfaceTemplate(ClassModel model, IProject project)
            : base(TemplateId, project, model)
        {
        }

        public string RepositoryInterfaceName => GetTypeName(RepositoryInterfaceTemplate.Identifier);

        public string EntityStateName => GetTypeName("Domain.Entities", Model);

        public string EntityInterfaceName => GetTypeName("Domain.Entities.Interfaces", Model); 

        //public string PrimaryKeyType => Model.Attributes.Any(x => x.HasStereotype("Primary Key")) ? GetTypeName(Model.Attributes.First(x => x.HasStereotype("Primary Key")).Type) : UseType(ExecutionContext.Settings.GetEntityKeySettings()?.KeyType().Value ?? "System.Guid");
        public string PrimaryKeyType => GetTemplate<ITemplate>("Domain.Entities", Model).GetMetadata().CustomMetadata.TryGetValue("Surrogate Key Type", out var type) ? UseType(type) : UseType("System.Guid");

        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"I{Model.Name}Repository",
                @namespace: $"{OutputTarget.GetNamespace()}");
        }
    }
}
