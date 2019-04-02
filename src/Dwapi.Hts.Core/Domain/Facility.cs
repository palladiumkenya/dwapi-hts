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
        public ICollection<HtsClient> MasterPatientIndices { get; set; }=new List<HtsClient>();
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