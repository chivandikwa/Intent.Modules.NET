using System;
using EfCoreTestSuite.TPT.IntentGenerated.Entities;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.TPT.IntentGenerated.Core
{
    public class FkDerivedClassConfiguration : IEntityTypeConfiguration<FkDerivedClass>
    {
        public void Configure(EntityTypeBuilder<FkDerivedClass> builder)
        {
            builder.ToTable("FkDerivedClass");
        }
    }
}