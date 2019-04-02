using System;
using Dwapi.Hts.SharedKernel.Enums;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Domain
{
    public class Cargo : Entity<Guid>
    {
        public CargoType Type { get; set; }
        public string Items { get; set; }
        public Guid ManifestId { get; set; }

        public Cargo()
        {
        }
    }
}