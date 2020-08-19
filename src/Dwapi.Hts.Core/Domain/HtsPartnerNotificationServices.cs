using System;
using Dwapi.Hts.SharedKernel.Custom;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Domain
{


    public class HtsPartnerNotificationServices : Entity<Guid>
    {
        public string FacilityName { get; set; }
        public int SiteCode { get; set; }
        public int PatientPk { get; set; }
        public string HtsNumber { get; set; }
        public string Emr { get; set; }
        public string Project { get; set; }
        public bool? Processed { get; set; }
        public string QueueId { get; set; }
        public string Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public DateTime? DateExtracted { get; set; }
        public int? PartnerPatientPk { get; set; }
        public int? PartnerPersonID { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
        public string RelationsipToIndexClient { get; set; }
        public string ScreenedForIpv { get; set; }
        public string IpvScreeningOutcome { get; set; }
        public string CurrentlyLivingWithIndexClient { get; set; }
        public string KnowledgeOfHivStatus { get; set; }
        public string PnsApproach { get; set; }
        public string PnsConsent { get; set; }
        public string LinkedToCare { get; set; }
        public DateTime? LinkDateLinkedToCare { get; set; }
        public string CccNumber { get; set; }
        public string FacilityLinkedTo { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? DateElicited { get; set; }
        public string MaritalStatus { get; set; }
        public Guid FacilityId { get; set; }

        public override void UpdateRefId()
        {
            RefId = Id;
            Id = LiveGuid.NewGuid();
        }
    }
}
