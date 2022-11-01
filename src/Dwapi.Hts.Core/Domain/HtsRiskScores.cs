using System;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Domain
{
    public class HtsRiskScores : Entity<Guid>
    {
        public Guid FacilityId { get; set; }
        
        public virtual string FacilityName { get; set; }
        public virtual int SiteCode { get; set; }
        public virtual int PatientPk { get; set; }
        public virtual string HtsNumber { get; set; }
        public virtual string Emr { get; set; }
        public virtual string Project { get; set; }
        public virtual bool? Processed { get; set; }
        public virtual string QueueId { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime? StatusDate { get; set; }
        public virtual DateTime? DateExtracted { get; set; }

        public string SourceSysUUID { get; set; }
        public decimal? RiskScore { get; set; }
        public string RiskFactors { get; set; }
        public string Description { get; set; }
        public DateTime? EvaluationDate { get; set; }
        
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
        
    }
}