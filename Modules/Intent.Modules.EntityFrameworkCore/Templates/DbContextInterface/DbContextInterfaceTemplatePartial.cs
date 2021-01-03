using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Eventing;
using Intent.Modelers.Domain.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.VisualStudio;
using Intent.Modules.Constants;
using Intent.Modules.Entities.Templates.DomainEntityState;
using Intent.Modules.EntityFrameworkCore.Templates.Configurations;
using Intent.Templates;
using Intent.RoslynWeaver.Attributes;

[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]
[assembly: DefaultIntentManaged(Mode.Merge)]

namespace Intent.Modules.EntityFrameworkCore.Templates.DbContextInterface
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class DbContextInterfaceTemplate : CSharpTemplateBase<IList<ClassModel>>
    {
        public const string Identifier = "Intent.EntityFrameworkCore.DbContextInterface";


        public DbContextInterfaceTemplate(IList<ClassModel> models, IOutputTarget outputTarget)
            : base(Identifier, outputTarget, models)
        {
            AddNugetDependency(NugetPackages.EntityFrameworkCore);
        }

        public string GetEntityName(ClassModel model)
        {
            return GetTypeName(DomainEntityStateTemplate.TemplateId, model);
        }

        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"I{Project.Application.Name}DbContext".ToCSharpIdentifier(),
                @namespace: $"{OutputTarget.GetNamespace()}");
        }

        public string GetMappingClassName(ClassModel model)
        {
            return GetTypeName(ConfigurationsTemplate.Identifier, model);
        }
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Intent.EntityFrameworkCore.DbContextInterface";
    }
}
