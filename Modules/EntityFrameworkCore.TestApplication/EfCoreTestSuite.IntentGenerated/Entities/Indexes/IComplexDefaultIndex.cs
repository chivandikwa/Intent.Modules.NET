using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityInterface", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Entities.Indexes
{

    public interface IComplexDefaultIndex
    {

        Guid FieldA { get; set; }

        Guid FieldB { get; set; }

    }
}
