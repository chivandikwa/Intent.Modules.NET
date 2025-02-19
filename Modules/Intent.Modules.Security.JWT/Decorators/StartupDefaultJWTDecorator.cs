using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intent.Engine;
using Intent.Modules.AspNetCore.Templates.Startup;
using Intent.Modules.Common;
using Intent.Modules.Common.VisualStudio;
using Intent.Modules.Security.JWT.Events;
using Intent.Modules.Security.JWT.Templates.ConfigurationJWTAuthentication;
using Intent.RoslynWeaver.Attributes;

[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateDecorator", Version = "1.0")]
[assembly: DefaultIntentManaged(Mode.Merge)]

namespace Intent.Modules.Security.JWT.Decorators
{
    [IntentManaged(Mode.Merge)]
    public class StartupDefaultJWTDecorator : StartupDecorator
    {
        [IntentManaged(Mode.Fully)]
        public const string DecoratorId = "Intent.Security.JWT.StartupDefaultJWTDecorator";

        [IntentManaged(Mode.Fully)]
        private readonly StartupTemplate _template;
        [IntentManaged(Mode.Fully)]
        private readonly IApplication _application;

        [IntentManaged(Mode.Merge)]
        public StartupDefaultJWTDecorator(StartupTemplate template, IApplication application)
        {
            _template = template;
            _application = application;
            Priority = -10;
            _template.AddTemplateDependency(ConfigurationJWTAuthenticationTemplate.TemplateId);
        }

        public override string Configuration()
        {
            return "app.UseAuthentication();";
        }

        public override string ConfigureServices()
        {
            return @"services.ConfigureJWTSecurity(Configuration);";
        }
    }
}
