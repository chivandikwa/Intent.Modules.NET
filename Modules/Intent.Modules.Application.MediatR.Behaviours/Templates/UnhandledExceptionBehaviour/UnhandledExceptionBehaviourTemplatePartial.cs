using System.Collections.Generic;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.DependencyInjection;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.Application.MediatR.Behaviours.Templates.UnhandledExceptionBehaviour
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class UnhandledExceptionBehaviourTemplate : CSharpTemplateBase<object>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Intent.Application.MediatR.Behaviours.UnhandledExceptionBehaviour";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public UnhandledExceptionBehaviourTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
        {
            AddNugetDependency(NuGetPackages.MicrosoftExtensionsLogging);
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"UnhandledExceptionBehaviour",
                @namespace: $"{OutputTarget.GetNamespace()}");
        }

        public override void BeforeTemplateExecution()
        {
            ExecutionContext.EventDispatcher.Publish(ContainerRegistrationRequest.ToRegister($"typeof({ClassName}<,>)")
                .ForInterface("typeof(IPipelineBehavior<,>)")
                .WithPriority(0)
                .ForConcern("Application")
                .RequiresUsingNamespaces("MediatR")
                .HasDependency(this));
        }

    }
}