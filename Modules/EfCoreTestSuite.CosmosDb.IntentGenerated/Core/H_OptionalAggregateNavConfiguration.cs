using System;
using EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.Associations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Core
{
    public class H_OptionalAggregateNavConfiguration : IEntityTypeConfiguration<H_OptionalAggregateNav>
    {
        public void Configure(EntityTypeBuilder<H_OptionalAggregateNav> builder)
        {
            builder.ToContainer("PartitionKeyNamed");

            builder.HasPartitionKey(x => x.PartitionKey);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PartitionKey)
                .IsRequired();

            builder.Property(x => x.OptionalAggrNavAttr)
                .IsRequired();

            builder.HasMany(x => x.H_MultipleDependents)
                .WithOne(x => x.H_OptionalAggregateNav)
                .HasForeignKey(x => x.H_OptionalAggregateNavId);
        }
    }
}