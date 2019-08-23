using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.SharedKernel.Interfaces;

namespace Dwapi.Hts.Core.Interfaces.Repository
{
    public interface IHtsHtsTestKitsRepository : IRepository<HtsTestKits,Guid>
    {
        void Process(Guid facilityId,IEnumerable<HtsTestKits> clients);
    }
}