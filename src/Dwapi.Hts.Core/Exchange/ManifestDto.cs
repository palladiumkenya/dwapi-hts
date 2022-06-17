using System;
using System.Linq;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.SharedKernel.Enums;
using Newtonsoft.Json;

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
            if(cargoes.Any())
                Cargo = JsonConvert.SerializeObject(cargoes);
        }
    }
}
