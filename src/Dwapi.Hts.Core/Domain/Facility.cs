using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Domain
{
    public class Facility : Entity<Guid>
    {
        public int SiteCode { get; set; }
        [MaxLength(120)] public string Name { get; set; }
        public int? MasterFacilityId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public ICollection<HtsClient> Clients { get; set; }=new List<HtsClient>();
        public ICollection<HtsClientTests> ClientTestses { get; set; }=new List<HtsClientTests>();
        public ICollection<HtsClientLinkage> Linkages { get; set; }=new List<HtsClientLinkage>();
        public ICollection< HtsClientPartner> Partners { get; set; }=new List<HtsClientPartner>();
        public ICollection<HtsClientTracing> ClientTracings { get; set; } = new List<HtsClientTracing>();
        public ICollection<HtsPartnerNotificationServices> PartnerNotifications { get; set; } = new List<HtsPartnerNotificationServices>();
        public ICollection<HtsPartnerTracing> HtsPartnerTracings { get; set; } = new List<HtsPartnerTracing>();
        public ICollection<HtsTestKits> Kitses { get; set; } = new List<HtsTestKits>();
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

        public override string ToString()
        {
            return $"{Name} - {SiteCode}";
        }
    }
}
