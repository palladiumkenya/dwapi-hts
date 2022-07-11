using System;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Domain
{
    public class HtsEligibilityExtract : Entity<Guid>
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

  public string EncounterId { get; set; }
        public int? VisitID { get; set; }
        public DateTime? VisitDate { get; set; }
        public string PopulationType { get; set; }
        public string KeyPopulation { get; set; }
        public string PriorityPopulation { get; set; }
        public string Department { get; set; }
        public string PatientType { get; set; }
        public string IsHealthWorker { get; set; }
        public string RelationshipWithContact { get; set; }
        public string TestedHIVBefore { get; set; }
        public string WhoPerformedTest { get; set; }
        public string ResultOfHIV { get; set; }
        public DateTime? DateTested  { get; set; }
        public string StartedOnART { get; set; }
        public string CCCNumber { get; set; }
        public string EverHadSex { get; set; }
        public string SexuallyActive { get; set; }
        public string NewPartner { get; set; }
        public string PartnerHivStatus { get; set; }
        public string CoupleDiscordant { get; set; }
        public string MultiplePartners { get; set; }
        public int? NumberOfPartners { get; set; }
        public string AlcoholSex { get; set; }
        public string MoneySex { get; set; }
        public string CondomBurst { get; set; }
        public string UnknownStatusPartner { get; set; }
        public string KnownStatusPartner { get; set; }
        public string Pregnant { get; set; }
        public string BreastfeedingMother { get; set; }
        public string ExperiencedGBV { get; set; }
        public string PhysicalViolence { get; set; }
        public string SexualViolence { get; set; }
        public string EverOnPrep { get; set; }
        public string CurrentlyOnPrep { get; set; }
        public string EverOnPep { get; set; }
        public string CurrentlyOnPep { get; set; }
        public string EverHadSTI { get; set; }
        public string CurrentlyHasSTI { get; set; }
        public string EverHadTB { get; set; }
        public string CurrentlyHasTB { get; set; }
        public string SharedNeedle { get; set; }
        public string NeedleStickInjuries { get; set; }
        public string TraditionalProcedures { get; set; }
        public string ChildReasonsForIneligibility { get; set; }
        public string EligibleForTest { get; set; }
        public string ReasonsForIneligibility { get; set; }
        public int? SpecificReasonForIneligibility { get; set; }
        public Guid FacilityId { get; set; }
    }
}