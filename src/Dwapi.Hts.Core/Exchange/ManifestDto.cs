using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Domain.Dto;
using Dwapi.Hts.SharedKernel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dwapi.Hts.Core.Exchange
{
    public class ManifestDto
    {
        public Guid Id { get; set; }
        public int FacilityCode { get; set; }
        public string FacilityName { get; set; }
        public string Docket { get; set; }
        public DateTime LogDate { get; set; }
        public DateTime BuildDate { get; set; }
        public int PatientCount { get; set; }
        public string Cargo { get; set; }
        public Guid? Session { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Tag { get; set; }

        public ManifestDto(Manifest manifest, int count)
        {
            Id = manifest.Id;
            FacilityCode = manifest.SiteCode;
            FacilityName = manifest.Name;
            Docket = "HTS";
            LogDate = manifest.DateLogged;
            BuildDate = manifest.DateArrived;
            PatientCount = count;
            Session = manifest.Session;
            Start = manifest.Start;
            End = manifest.End;
            Tag = manifest.Tag;
            var cargoes = manifest.Cargoes.Where(x => x.Type != CargoType.Patient).ToList();
            var serializerSettings=new JsonSerializerSettings() {ContractResolver = new CamelCasePropertyNamesContractResolver()};
            if(cargoes.Any())
              Cargo=  JsonConvert.SerializeObject(ExtractDto.GenerateCargo(cargoes), serializerSettings);
        }
    }

    public class ExtractDto
    {
        public string Name { get; set; }
        public int? NoLoaded { get; set; }
        public string Version { get; set; }
        public string LogValue { get; set; }
        public DateTime? ActionDate { get; set; }
        public List<ExtractCargoDto> ExtractCargos { get; set; } = new List<ExtractCargoDto>();

        public static ExtractDto Generate(List<Cargo> cargoBox)
        {
            var extractDto = new ExtractDto();

            var cargoes = cargoBox.Where(x =>
                    x.Type == CargoType.AppMetrics &&
                    x.Items.Contains("HivTestingService") &&
                    x.Items.Contains("ExtractCargos"))
                .Select(c => c.Items)
                .ToList();

            foreach (var cargo in cargoes)
            {
                var temp = JsonConvert.DeserializeObject<ExtractDto>(cargo);
                if (null != temp && !string.IsNullOrWhiteSpace(temp.LogValue))
                {
                    extractDto = JsonConvert.DeserializeObject<ExtractDto>(temp.LogValue);
                    if (extractDto.ExtractCargos.Any())
                        return extractDto;
                }
            }

            return extractDto;
        }

        public static List<ExtractCargoDto> GenerateCargo(List<Cargo> cargoBox)
        {
            var extractDto = Generate(cargoBox);
            return extractDto.ExtractCargos;
        }
    }

    public class ExtractCargoDto
    {
        public string DocketId { get; set; }
        public string Name { get; set; }
        public int? Stats { get; set; }
    }
}
