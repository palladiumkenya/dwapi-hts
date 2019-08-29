using System.Linq;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.Core.Interfaces.Service;
using Dwapi.Hts.SharedKernel.Enums;

namespace Dwapi.Hts.Core.Service
{
    public class ManifestService:IManifestService
    {
        private readonly IManifestRepository _manifestRepository;
        private  readonly ILiveSyncService _liveSyncService;

        public ManifestService(IManifestRepository manifestRepository, ILiveSyncService liveSyncService)
        {
            _manifestRepository = manifestRepository;
            _liveSyncService = liveSyncService;
        }

        public void Process()
        {
            var manifests = _manifestRepository.GetAll(x => x.Status == ManifestStatus.Staged).ToList();
            if (manifests.Any())
            {
                _manifestRepository.ClearFacility(manifests);

                foreach (var manifest in manifests)
                {
                    var clientCount = _manifestRepository.GetPatientCount(manifest.Id);
                    _liveSyncService.SyncManifest(manifest,clientCount);
                }
            }
        }
    }
}
