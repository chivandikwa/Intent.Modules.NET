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
    public class CustomIndexConfiguration : IEntityTypeConfiguration<CustomIndex>
    {
        public void Configure(EntityTypeBuilder<CustomIndex> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IndexField)
                .IsRequired();

            builder.HasIndex(x => x.IndexField);
        }
    }
}