using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dwapi.Hts.Core.Domain.Dto;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.SharedKernel.Interfaces;

namespace Dwapi.Hts.Core.Interfaces.Repository
{
    public interface IManifestRepository : IRepository<Manifest, Guid>
    {
        void ClearFacility(IEnumerable<Manifest> manifests);
        int GetPatientCount(Guid id);
        IEnumerable<Manifest> GetStaged();
        Task EndSession(Guid session);
        IEnumerable<HandshakeDto> GetSessionHandshakes(Guid session);
    }
}
