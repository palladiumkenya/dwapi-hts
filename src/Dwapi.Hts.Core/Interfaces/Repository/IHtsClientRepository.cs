using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.SharedKernel.Interfaces;

namespace Dwapi.Hts.Core.Interfaces.Repository
{
    public interface IHtsClientRepository : IRepository<HtsClient,Guid>
    {
        void Process(Guid facilityId,IEnumerable<HtsClient> clients);
    }
}
