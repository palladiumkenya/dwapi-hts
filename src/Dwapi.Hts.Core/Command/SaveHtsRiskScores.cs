 using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class SaveHtsRiskScores: IRequest<Guid>
    {
        public IEnumerable<HtsRiskScores> RiskScores { get; set; }

        public SaveHtsRiskScores( IEnumerable<HtsRiskScores> riskScores)
        {

            RiskScores = riskScores;
        }
    }
}