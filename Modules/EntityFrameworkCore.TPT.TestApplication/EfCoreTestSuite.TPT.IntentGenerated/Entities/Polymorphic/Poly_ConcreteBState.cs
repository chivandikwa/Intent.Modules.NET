using System;
using System.Collections.Generic;
using EfCoreTestSuite.TPT.IntentGenerated.DomainEvents;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.TPT.IntentGenerated.Entities.Polymorphic
{

    public partial class Poly_ConcreteB : Poly_BaseClassNonAbstract, IPoly_ConcreteB
    {

        public string ConcreteField { get; set; }

    }
}
