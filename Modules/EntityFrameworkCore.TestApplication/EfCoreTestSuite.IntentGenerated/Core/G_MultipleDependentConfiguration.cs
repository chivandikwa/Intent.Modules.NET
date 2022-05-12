using System;
using EfCoreTestSuite.IntentGenerated.Entities;
using EfCoreTestSuite.IntentGenerated.Entities.Associations;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Core
{
    public class G_MultipleDependentConfiguration : IEntityTypeConfiguration<G_MultipleDependent>
    {
        public void Configure(EntityTypeBuilder<G_MultipleDependent> builder)
        {
            builder.HasKey(x => x.Id);


        }
    }
}