using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public override string ToString()
        {
            return $"{Name} [{County}]";
        }
    }
}