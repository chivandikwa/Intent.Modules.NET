using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace CqrsAutoCrud.TestApplication.Domain.Entities
{
    [IntentManaged(Mode.Merge)]
    [DefaultIntentManaged(Mode.Merge, Signature = Mode.Fully, Body = Mode.Ignore, Targets = Targets.Methods, AccessModifiers = AccessModifiers.Public)]
    public partial class CompositeManyAA
    {
        public Guid Id { get; set; }

        public string CompositeAttr { get; set; }

        public Guid ACompositeSingleId { get; set; }

        public Guid A_Composite_SingleId { get; set; }

    }
}