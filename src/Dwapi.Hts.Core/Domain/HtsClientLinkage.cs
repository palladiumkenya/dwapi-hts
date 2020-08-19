using System;
using Dwapi.Hts.SharedKernel.Custom;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Domain
{
    public class HtsClientLinkage : Entity<Guid>
    {
        public virtual string FacilityName { get; set; }
        public virtual int SiteCode { get; set; }
        public virtual int PatientPk { get; set; }
        public virtual string HtsNumber { get; set; }
        public virtual string Emr { get; set; }
        public virtual string Project { get; set; }
        public virtual bool? Processed { get; set; }
        public virtual string QueueId { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime? StatusDate { get; set; }
        public virtual DateTime? DateExtracted { get; set; }

        public DateTime? PhoneTracingDate { get; set; }
        public DateTime? PhysicalTracingDate { get; set; }
        public string TracingOutcome { get; set; }
        public string CccNumber { get; set; }
        public string EnrolledFacilityName { get; set; }
        public DateTime? ReferralDate { get; set; }
        public DateTime? DateEnrolled { get; set; }

        public  DateTime?  DatePrefferedToBeEnrolled { get; set; }
        public  string FacilityReferredTo { get; set; }
        public  string  HandedOverTo { get; set; }
        public  string HandedOverToCadre { get; set; }
        public  string ReportedCCCNumber { get; set; }
        public  DateTime? ReportedStartARTDate { get; set; }
        public Guid FacilityId { get; set; }

        public override void UpdateRefId()
        {
            RefId = Id;
            Id = Guid.NewGuid();
        }


    }
}
