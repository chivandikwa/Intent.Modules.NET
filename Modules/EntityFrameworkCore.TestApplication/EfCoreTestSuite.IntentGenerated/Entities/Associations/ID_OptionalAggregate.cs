using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityInterface", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Entities.Associations
{

    public interface ID_OptionalAggregate
    {

        string OptionalAggrAttr { get; set; }

        ICollection<ID_MultipleDependent> D_MultipleDependents { get; set; }

    }
}
