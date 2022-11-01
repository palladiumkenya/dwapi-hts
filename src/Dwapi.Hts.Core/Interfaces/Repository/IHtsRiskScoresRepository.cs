using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.SharedKernel.Interfaces;

namespace Dwapi.Hts.Core.Interfaces.Repository
{
    public interface IHtsRiskScoresRepository: IRepository<HtsRiskScores,Guid>
    {
        void Process(Guid facilityId,IEnumerable<HtsRiskScores> clients);
    }
}