using Intent.Engine;
using Intent.Modules.AspNetCore.Cors.Templates.CorsConfiguration;
using Intent.Modules.AspNetCore.Templates.Startup;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateDecorator", Version = "1.0")]

namespace Intent.Modules.AspNetCore.Cors.Decorators
{
    [IntentManaged(Mode.Merge)]
    public class CorsStartupDecorator : StartupDecorator
    {
        [IntentManaged(Mode.Fully)]
        public const string DecoratorId = "Intent.Modules.AspNetCore.Cors.CorsStartupDecorator";

        [IntentManaged(Mode.Fully)]
        private readonly StartupTemplate _template;
        [IntentManaged(Mode.Fully)]
        private readonly IApplication _application;

        [IntentManaged(Mode.Merge)]
        public CorsStartupDecorator(StartupTemplate template, IApplication application)
        {
            _template = template;
            _application = application;

            var configurationTemplate = _template.OutputTarget.FindTemplateInstance<IClassProvider>(CorsConfigurationTemplate.TemplateId);
            _template.AddTemplateDependency(CorsConfigurationTemplate.TemplateId);
            _template.AddUsing(configurationTemplate.Namespace);
            Priority = -2;
        }

        public override string ConfigureServices()
        {
            return $@"
            services.ConfigureCors();";
        }

        public override string Configuration()
        {
            return @"
            app.UseCors();";
        }
    }
}