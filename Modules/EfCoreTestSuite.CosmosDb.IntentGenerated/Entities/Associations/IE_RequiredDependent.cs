using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityInterface", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.Associations
{
    public interface IE_RequiredDependent
    {

        string RequiredDependentAttr { get; set; }

        IE_RequiredCompositeNav E_RequiredCompositeNav { get; set; }
    }
}