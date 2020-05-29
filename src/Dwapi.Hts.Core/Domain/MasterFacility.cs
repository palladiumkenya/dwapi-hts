using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Domain
{
    public class MasterFacility:Entity<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }

        [MaxLength(120)]
        public string Name { get; set; }
        [MaxLength(120)]
        public string County { get; set; }
        public DateTime? SnapshotDate { get; set; }
        public int? SnapshotSiteCode { get; set; }
        public int? SnapshotVersion { get; set; }

        public ICollection<Facility> Mentions { get; set; }=new List<Facility>();

        public MasterFacility()
        {
        }

        public MasterFacility(int id, string name, string county)
        {
            Id = id;
            Name = name;
            County = county;
        }

        public MasterFacility TakeSnap(List<MasterFacility> mflSnaps)
        {
            MasterFacility lastSnap = null;

            if (mflSnaps.Any())
                lastSnap = mflSnaps
                    .OrderBy(x => x.SnapshotDate)
                    .ThenBy(x=>x.SnapshotVersion)
                    .Last();

            var snapVersion = null == lastSnap ? 1 : lastSnap.GetNextSnapshotVersion();

            var snapSiteCode = Convert.ToInt32($"-{100 + snapVersion}{Id}");

            var fac = this;
            fac.SnapshotSiteCode = Id;
            fac.Id =snapSiteCode;
            fac.SnapshotDate = DateTime.Now;
            fac.SnapshotVersion = snapVersion;
            return fac;
        }

        private int GetNextSnapshotVersion()
        {
            if (SnapshotVersion.HasValue)
                return SnapshotVersion.Value + 1;

            return 0;
        }

        public override string ToString()
        {
            return $"{Name} [{County}]";
        }
    }
}
