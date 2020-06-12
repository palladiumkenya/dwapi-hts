using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Hts.SharedKernel.Enums;

namespace Dwapi.Hts.Core.Domain.Dto
{
    public class MetricDto
    {
        public Guid Id { get; set; }
        public int FacilityCode { get; set; }
        public string FacilityName { get; set; }
        public string Cargo { get; set; }
        public CargoType CargoType { get; set; }
        public Guid FacilityManifestId { get; set; }

        public MetricDto(MasterFacility facility, Cargo manifestCargo)
        {
            Id = manifestCargo.Id;
            FacilityCode = facility.Id;
            FacilityName = facility.Name;
            Cargo = manifestCargo.Items;
            CargoType = manifestCargo.Type;
            FacilityManifestId = manifestCargo.ManifestId;
        }

        public MetricDto(int code, string fac, Cargo manifestCargo)
        {
            Id = manifestCargo.Id;
            FacilityCode = code;
            FacilityName = fac;
            Cargo = manifestCargo.Items;
            CargoType = manifestCargo.Type;
            FacilityManifestId = manifestCargo.ManifestId;
        }

        public static List<MetricDto> Generate(MasterFacility masterFacility, Manifest facManifest)
        {
            var metrics = new List<MetricDto>();
            foreach (var cargo in facManifest.Cargoes)
            {
                metrics.Add(new MetricDto(masterFacility, cargo));
            }

            return metrics
                .Where(x => x.CargoType != CargoType.Patient)
                .ToList();
        }
    }
}
