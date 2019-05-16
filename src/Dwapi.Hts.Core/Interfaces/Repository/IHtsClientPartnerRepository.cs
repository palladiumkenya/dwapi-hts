using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.SharedKernel.Interfaces;

namespace Dwapi.Hts.Core.Interfaces.Repository
{
    public interface IHtsClientPartnerRepository : IRepository<HtsClientPartner,Guid>
    {
        void Process(Guid facilityId,IEnumerable<HtsClientPartner> clients);
    }
}