using System.Collections.Generic;
using Intent.Engine;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modules.DomainEvents.Templates.DomainEventBase;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;


[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.DomainEvents.Templates.DomainEventServiceInterface
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class DomainEventServiceInterfaceTemplate : CSharpTemplateBase<object>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Intent.DomainEvents.DomainEventServiceInterface";

        public DomainEventServiceInterfaceTemplate(IOutputTarget outputTarget, object model) : base(TemplateId, outputTarget, model)
        {
        }

        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"IDomainEventService",
                @namespace: $"{OutputTarget.GetNamespace()}");
        }

        private string GetDomainEventBaseType()
        {
            return GetTypeName(DomainEventBaseTemplate.TemplateId);
        }
    }
}