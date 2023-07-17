using System;
using System.Collections.Generic;
using Dwapi.Hts.SharedKernel.Enums;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Domain
{
    public class Manifest : Entity<Guid>
    {
        public int SiteCode { get; set; }
        public string Name { get; set; }
        public int Sent { get; set; }
        public int Recieved { get; set; }
        public DateTime DateLogged { get; set; }
        public DateTime DateArrived { get; set; } = DateTime.Now;
        public ManifestStatus Status { get; set; }
        public DateTime StatusDate { get; set; } = DateTime.Now;
        public Guid FacilityId { get; set; }
        public Guid? EmrId { get; set; }
        public string EmrName { get; set; }
        public EmrSetup EmrSetup { get; set; }

        public Guid? Session { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Tag { get; set; }
        
        public ICollection<Cargo> Cargoes { get; set; } = new List<Cargo>();

        public Manifest()
        {
        }

        public void UpdateFacility(Guid facilityId)
        {
            FacilityId = facilityId;
        }
        
        public bool IsValid()
        {
            return SiteCode > 0 && Cargoes.Count > 0;
        }
        public void Validate()
        {
            if (!IsValid())
                throw new Exception($"Invalid Manifest,Please ensure the SiteCode [{SiteCode}] is valid and there exists at least one (1) Patient record");
        }
    }
}
