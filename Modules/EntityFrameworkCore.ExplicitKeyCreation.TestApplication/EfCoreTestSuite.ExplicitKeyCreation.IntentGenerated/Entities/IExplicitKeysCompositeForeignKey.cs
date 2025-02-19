using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityInterface", Version = "1.0")]

namespace EfCoreTestSuite.ExplicitKeyCreation.IntentGenerated.Entities
{

    public interface IExplicitKeysCompositeForeignKey
    {

        Guid Id { get; set; }

        Guid ExplicitKeysCompositeKeyCompositeKeyA { get; set; }

        Guid ExplicitKeysCompositeKeyCompositeKeyB { get; set; }

        IExplicitKeysCompositeKey ExplicitKeysCompositeKey { get; set; }

    }
}
