using System.ComponentModel;
using Intent.Engine;
using Intent.Modules.Common.Registrations;
using Intent.Modules.IdentityServer4.UI.Templates.Controllers.AccountController;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateDecoratorRegistration", Version = "1.0")]

namespace Intent.Modules.IdentityServer4.UI.Interop.Identity.EFCore.Decorators
{
    [Description(AccountSignInManagerDecorator.DecoratorId)]
    public class AccountSignInManagerDecoratorRegistration : DecoratorRegistration<AccountControllerTemplate, AccountAuthProviderDecorator>
    {
        public override AccountAuthProviderDecorator CreateDecoratorInstance(AccountControllerTemplate template, IApplication application)
        {
            return new AccountSignInManagerDecorator(template, application);
        }

        public override string DecoratorId => AccountSignInManagerDecorator.DecoratorId;
    }
}