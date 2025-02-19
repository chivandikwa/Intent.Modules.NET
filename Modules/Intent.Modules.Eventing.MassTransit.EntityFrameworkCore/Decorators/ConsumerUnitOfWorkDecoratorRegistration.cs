using System.ComponentModel;
using Intent.Engine;
using Intent.Modules.Common.Registrations;
using Intent.Modules.Eventing.MassTransit.Templates.WrapperConsumer;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateDecoratorRegistration", Version = "1.0")]

namespace Intent.Modules.Eventing.MassTransit.EntityFrameworkCore.Decorators
{
    [Description(ConsumerUnitOfWorkDecorator.DecoratorId)]
    public class ConsumerUnitOfWorkDecoratorRegistration : DecoratorRegistration<WrapperConsumerTemplate, ConsumerDecorator>
    {
        public override ConsumerDecorator CreateDecoratorInstance(WrapperConsumerTemplate template, IApplication application)
        {
            return new ConsumerUnitOfWorkDecorator(template, application);
        }

        public override string DecoratorId => ConsumerUnitOfWorkDecorator.DecoratorId;
    }
}