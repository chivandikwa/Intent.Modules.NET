using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CqrsAutoCrud.TestApplication.Domain.Entities;
using CqrsAutoCrud.TestApplication.Domain.Repositories;
using CqrsAutoCrud.TestApplication.Infrastructure.Persistence;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace CqrsAutoCrud.TestApplication.Infrastructure.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class AggregateRootLongRepository : RepositoryBase<AggregateRootLong, AggregateRootLong, ApplicationDbContext>, IAggregateRootLongRepository
    {
        [IntentManaged(Mode.Ignore, Signature = Mode.Fully)]
        public AggregateRootLongRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }


        [IntentManaged(Mode.Fully)]
        public async Task<AggregateRootLong> FindByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }


        [IntentManaged(Mode.Fully)]
        public async Task<List<AggregateRootLong>> FindByIdsAsync(long[] ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.Id), cancellationToken);
        }
    }
}