using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dwapi.Hts.SharedKernel.Model;
using Dwapi.Hts.SharedKernel.Utils;

namespace Dwapi.Hts.Core.Domain
{
    public class Facility : Entity<Guid>
    {
        public int SiteCode { get; set; }
        [MaxLength(120)] public string Name { get; set; }
        public int? MasterFacilityId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Emr { get; set; }
        public DateTime? SnapshotDate { get; set; }
        public int? SnapshotSiteCode { get; set; }
        public int? SnapshotVersion { get; set; }
        public ICollection<HtsClient> Clients { get; set; }=new List<HtsClient>();
        public ICollection<HtsClientTests> ClientTestses { get; set; }=new List<HtsClientTests>();
        public ICollection<HtsClientLinkage> Linkages { get; set; }=new List<HtsClientLinkage>();
        public ICollection< HtsClientPartner> Partners { get; set; }=new List<HtsClientPartner>();
        public ICollection<HtsClientTracing> ClientTracings { get; set; } = new List<HtsClientTracing>();
        public ICollection<HtsPartnerNotificationServices> PartnerNotifications { get; set; } = new List<HtsPartnerNotificationServices>();
        public ICollection<HtsPartnerTracing> HtsPartnerTracings { get; set; } = new List<HtsPartnerTracing>();
        public ICollection<HtsTestKits> Kitses { get; set; } = new List<HtsTestKits>();
        public ICollection<HtsEligibilityExtract> Eligibility { get; set; } = new List<HtsEligibilityExtract>();

        public ICollection<Manifest> Manifests { get; set; }=new List<Manifest>();

        public Facility()
        {
        }

        public Facility(int siteCode, string name)
        {
            SiteCode = siteCode;
            Name = name;
        }

        public Facility(int siteCode, string name, int? masterFacilityId):this(siteCode,name)
        {
            MasterFacilityId = masterFacilityId;
        }

        public bool EmrChanged(string requestEmr)
        {
            if (string.IsNullOrWhiteSpace(requestEmr))
                return false;

            if (string.IsNullOrWhiteSpace(Emr))
                return false;

            if (requestEmr.IsSameAs("CHAK"))
                requestEmr = "IQCare";

            if (requestEmr.IsSameAs("IQCare") || requestEmr.IsSameAs("KenyaEMR"))
                return !Emr.IsSameAs(requestEmr);

            return false;
        }

        public Facility TakeSnapFrom(MasterFacility snapMfl)
        {
            var fac = this;

            fac.SnapshotDate = DateTime.Now;
            fac.SiteCode = snapMfl.Id;
            fac.SnapshotSiteCode = snapMfl.SnapshotSiteCode;
            fac.SnapshotVersion = snapMfl.SnapshotVersion;

            return fac;
        }

        public override string ToString()
        {
            return $"{Name} - {SiteCode}";
        }
    }
}
