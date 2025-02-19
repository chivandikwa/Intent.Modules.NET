using System.Collections.Generic;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.AspNetCore.MultiTenancy.Templates.MultiTenantStoreDbContext
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    partial class MultiTenantStoreDbContextTemplate : CSharpTemplateBase<object>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Intent.Modules.AspNetCore.MultiTenancy.MultiTenantStoreDbContext";

        [IntentManaged(Mode.Ignore, Signature = Mode.Fully)]
        public MultiTenantStoreDbContextTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
        {
            AddNugetDependency("Finbuckle.MultiTenant.EntityFrameworkCore", "6.5.1");
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"MultiTenantStoreDbContext",
                @namespace: $"{this.GetNamespace()}",
                relativeLocation: $"{this.GetFolderPath()}");
        }
    }
}