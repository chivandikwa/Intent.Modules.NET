using System;
using EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.Polymorphic;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Core
{
    public class Poly_SecondLevelConfiguration : IEntityTypeConfiguration<Poly_SecondLevel>
    {
        public void Configure(EntityTypeBuilder<Poly_SecondLevel> builder)
        {
            builder.ToContainer("EntityFrameworkCore.CosmosDb.TestApplication");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SecondField)
                .IsRequired();

            builder.Property(x => x.PartitionKey)
                .IsRequired();
            builder.HasPartitionKey(x => x.PartitionKey);

            builder.HasMany(x => x.Poly_BaseClassNonAbstracts)
                .WithOne()
                .HasForeignKey(x => x.Poly_SecondLevelId);
        }
    }
}