using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityInterface", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Entities.Associations
{

    public interface IL_SelfReferenceMultiple
    {

        string SelfRefMultipleAttr { get; set; }

        ICollection<IL_SelfReferenceMultiple> L_SelfReferenceMultiplesDst { get; set; }

    }
}
