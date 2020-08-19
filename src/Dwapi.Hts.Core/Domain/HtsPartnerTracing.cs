using System;
using Dwapi.Hts.SharedKernel.Custom;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Domain
{


        public  class HtsPartnerTracing : Entity<Guid>
        {
            public  string FacilityName { get; set; }
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
            public  string TraceType { get; set; }
            public  DateTime? TraceDate { get; set; }
            public  string TraceOutcome { get; set; }
            public  DateTime? BookingDate { get; set; }
            public Guid FacilityId { get; set; }
            public int? PartnerPersonID { get; set; }

            public override void UpdateRefId()
            {
                RefId = Id;
                Id = LiveGuid.NewGuid();
            }
    }
}
