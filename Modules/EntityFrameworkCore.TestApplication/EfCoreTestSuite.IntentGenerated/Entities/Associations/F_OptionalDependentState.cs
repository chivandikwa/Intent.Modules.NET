using System;
using System.Collections.Generic;
using EfCoreTestSuite.IntentGenerated.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Entities.Associations
{

    public partial class F_OptionalDependent : IF_OptionalDependent
    {

        public Guid Id { get; set; }

        public string OptionalDepAttr { get; set; }

        public virtual F_OptionalAggregateNav F_OptionalAggregateNav { get; set; }

        IF_OptionalAggregateNav IF_OptionalDependent.F_OptionalAggregateNav
        {
            get => F_OptionalAggregateNav;
            set => F_OptionalAggregateNav = (F_OptionalAggregateNav)value;
        }
    }
}
