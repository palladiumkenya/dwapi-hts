using System;
using Dwapi.Hts.SharedKernel.Custom;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Domain
{
    public  class HtsTestKits :Entity<Guid>
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
        public  int? EncounterId { get; set; }
        public  string TestKitName1 { get; set; }
        public  string TestKitLotNumber1 { get; set; }
        public  string TestKitExpiry1 { get; set; }
        public  string TestResult1 { get; set; }
        public  string TestKitName2 { get; set; }
        public  string TestKitLotNumber2 { get; set; }
        public  string TestKitExpiry2{ get; set; }
        public  string TestResult2 { get; set; }
        public Guid FacilityId { get; set; }

        public override void UpdateRefId()
        {
            RefId = Id;
            Id = LiveGuid.NewGuid();
        }
    }
}
