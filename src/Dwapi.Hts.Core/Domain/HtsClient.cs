using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Domain
{
    public class HtsClient : Entity<Guid>
    {
        public int PatientPk { get; set; }
        public int SiteCode { get; set; }
        public string FacilityName { get; set; }
        public string Serial { get; set; }
        public DateTime DateExtracted { get; set; }
        public virtual bool? Processed { get; set; }
        public virtual string QueueId { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime? StatusDate { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public Guid FacilityId { get; set; }

        public ICollection<HtsClientPartner> HtsClientPartners { get; set; }=new List<HtsClientPartner>();
        public ICollection<HtsClientLinkage> HtsClientLinkages { get; set; }=new List<HtsClientLinkage>();
        public HtsClient()
        {
        }
    }
}
