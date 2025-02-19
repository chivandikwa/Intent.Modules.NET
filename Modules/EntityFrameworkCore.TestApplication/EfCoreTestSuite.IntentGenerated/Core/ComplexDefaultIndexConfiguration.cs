using System;
using EfCoreTestSuite.IntentGenerated.Entities;
using EfCoreTestSuite.IntentGenerated.Entities.Indexes;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Core
{
    public class ComplexDefaultIndexConfiguration : IEntityTypeConfiguration<ComplexDefaultIndex>
    {
        public void Configure(EntityTypeBuilder<ComplexDefaultIndex> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FieldA)
                .IsRequired();

            builder.Property(x => x.FieldB)
                .IsRequired();

            builder.HasIndex(x => new { x.FieldA, x.FieldB });
        }
    }
}