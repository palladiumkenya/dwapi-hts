using System.Linq;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.Core.Interfaces.Service;
using Dwapi.Hts.SharedKernel.Enums;

namespace Dwapi.Hts.Core.Service
{
    public class ManifestService:IManifestService
    {
        private readonly IManifestRepository _manifestRepository;

        public ManifestService(IManifestRepository manifestRepository)
        {
            _manifestRepository = manifestRepository;
        }

        public void Process()
        {
            var manifests = _manifestRepository.GetAll(x => x.Status == ManifestStatus.Staged).ToList();
            if (manifests.Any())
            {
                _manifestRepository.ClearFacility(manifests);
            }
        }
    }
}