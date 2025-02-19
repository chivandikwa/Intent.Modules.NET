using System;
using EfCoreTestSuite.IntentGenerated.Entities.ExplicitKeys;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Core
{
    public class PK_A_CompositeKeyConfiguration : IEntityTypeConfiguration<PK_A_CompositeKey>
    {
        public void Configure(EntityTypeBuilder<PK_A_CompositeKey> builder)
        {
            builder.HasKey(x => new { x.CompositeKeyA, x.CompositeKeyB });
        }
    }
}