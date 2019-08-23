using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.SharedKernel.Interfaces;

namespace Dwapi.Hts.Core.Interfaces.Repository
{
    public interface IHtsClientTestsRepository : IRepository<HtsClientTests,Guid>
    {
        void Process(Guid facilityId,IEnumerable<HtsClientTests> clients);
    }
}