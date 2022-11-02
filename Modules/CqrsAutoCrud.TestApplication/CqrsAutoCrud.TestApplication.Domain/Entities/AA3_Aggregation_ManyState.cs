using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace CqrsAutoCrud.TestApplication.Domain.Entities
{

    public partial class AA3_Aggregation_Many : IAA3_Aggregation_Many
    {
        public AA3_Aggregation_Many()
        {
        }


        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        private string _aggregationAttr;

        public string AggregationAttr
        {
            get { return _aggregationAttr; }
            set
            {
                _aggregationAttr = value;
            }
        }

        private Guid? _aAggregationSingleId;

        public Guid? AAggregationSingleId
        {
            get { return _aAggregationSingleId; }
            set
            {
                _aAggregationSingleId = value;
            }
        }

        public Guid? A_Aggregation_SingleId { get; set; }
    }
}
