using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Domain.Dto;
using Dwapi.Hts.SharedKernel.Enums;
using Dwapi.Hts.SharedKernel.Interfaces;

namespace Dwapi.Hts.Core.Interfaces.Repository
{
    public interface IManifestRepository : IRepository<Manifest, Guid>
    {
        void ClearFacility(IEnumerable<Manifest> manifests);
        void ClearFacility(IEnumerable<Manifest> manifests,string project);
        int GetPatientCount(Guid id);
        IEnumerable<Manifest> GetStaged(int siteCode);
        Task EndSession(Guid session);
        IEnumerable<HandshakeDto> GetSessionHandshakes(Guid session);
        Task<MasterFacility> VerifyFacility(int siteCode);

    }
}
