using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Modelers.Domain.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.VisualStudio;
using Intent.Modules.Entities.Repositories.Api.Templates.RepositoryInterface;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]
[assembly: DefaultIntentManaged(Mode.Fully)]

namespace Intent.Modules.Entities.Repositories.Api.Templates.EntityRepositoryInterface
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    partial class EntityRepositoryInterfaceTemplate : CSharpTemplateBase<ClassModel>
    {
        public const string TemplateId = "Intent.Entities.Repositories.Api.EntityRepositoryInterface";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public EntityRepositoryInterfaceTemplate(IOutputTarget outputTarget, ClassModel model)
            : base(TemplateId, outputTarget, model)
        {
        }

        public string RepositoryInterfaceName => GetTypeName(RepositoryInterfaceTemplate.TemplateId);

        public string EntityStateName => GetTypeName("Domain.Entities", Model);

        public string EntityInterfaceName => GetTypeName("Domain.Entities.Interfaces", Model);

        public string PrimaryKeyType => GetTemplate<ITemplate>("Domain.Entities", Model).GetMetadata().CustomMetadata.TryGetValue("Surrogate Key Type", out var type) ? UseType(type) : UseType("System.Guid");

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"I{Model.Name}Repository",
                @namespace: $"{OutputTarget.GetNamespace()}");
        }
    }
}
