using System.Threading.Tasks;

namespace EfCoreTestSuite.TPC.IntentGenerated.DomainEvents;

public class DomainEventService : IDomainEventService
{
    public Task Publish(DomainEvent domainEvent)
    {
        return Task.CompletedTask;
    }
}