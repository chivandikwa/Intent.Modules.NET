using System;
using System.Collections.Generic;
using EfCoreTestSuite.TPT.IntentGenerated.Core;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.TPT.IntentGenerated.Entities.Polymorphic
{

    public partial class Poly_RootAbstract_Comp : IPoly_RootAbstract_Comp
    {

        public Guid Id { get; set; }

        public string CompField { get; set; }


    }
}
