using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.Associations
{
    public partial class G_MultipleDependent : IG_MultipleDependent
    {
        public Guid Id { get; set; }

        public string MultipleDepAttr { get; set; }

        public virtual G_RequiredCompositeNav G_RequiredCompositeNav { get; set; }

        IG_RequiredCompositeNav IG_MultipleDependent.G_RequiredCompositeNav
        {
            get => G_RequiredCompositeNav;
            set => G_RequiredCompositeNav = (G_RequiredCompositeNav)value;
        }
    }
}