using System;
using EfCoreRepositoryTestSuite.IntentGenerated.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreRepositoryTestSuite.IntentGenerated.Core
{
    public class AggregateRoot3CollectionConfiguration : IEntityTypeConfiguration<AggregateRoot3Collection>
    {
        public void Configure(EntityTypeBuilder<AggregateRoot3Collection> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}