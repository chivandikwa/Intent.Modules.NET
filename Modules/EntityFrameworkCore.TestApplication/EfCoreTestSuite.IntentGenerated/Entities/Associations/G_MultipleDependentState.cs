using System;
using System.Collections.Generic;
using EfCoreTestSuite.IntentGenerated.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Entities.Associations
{

    public partial class G_MultipleDependent : IG_MultipleDependent
    {

        private string _multipleDepAttr;

        public string MultipleDepAttr
        {
            get { return _multipleDepAttr; }
            set
            {
                _multipleDepAttr = value;
            }
        }


        public Guid G_RequiredCompositeNavId { get; set; }

        public virtual G_RequiredCompositeNav G_RequiredCompositeNav
        { get; set; }

        IG_RequiredCompositeNav IG_MultipleDependent.G_RequiredCompositeNav
        {
            get => G_RequiredCompositeNav;
            set => G_RequiredCompositeNav = (G_RequiredCompositeNav)value;
        }


    }
}
