using System;
using Dwapi.Hts.SharedKernel.Custom;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Domain
{


        public  class HtsClientTracing : Entity<Guid>
        {

            public virtual string FacilityName { get; set; }
            public  int SiteCode { get; set; }
            public  int PatientPk { get; set; }
            public  string HtsNumber { get; set; }
            public  string Emr { get; set; }
            public  string Project { get; set; }
            public  bool? Processed { get; set; }
            public  string QueueId { get; set; }
            public  string Status { get; set; }
            public  DateTime? StatusDate { get; set; }
            public  DateTime? DateExtracted { get; set; }
            public  String TracingType { get; set; }
            public  DateTime? TracingDate { get; set; }
            public  string TracingOutcome { get; set; }
            public DateTime? Date_Created { get; set; }
            public DateTime? Date_Last_Modified { get; set; }
            public Guid FacilityId { get; set; }

            public override void UpdateRefId()
            {
                RefId = Id;
                Id = Guid.NewGuid();
        }
    }
}
