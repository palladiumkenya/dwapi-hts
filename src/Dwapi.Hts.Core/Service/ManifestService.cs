using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Dwapi.Hts.Core.Domain.Dto;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.Core.Interfaces.Service;
using Dwapi.Hts.SharedKernel.Enums;
using Serilog;

namespace Dwapi.Hts.Core.Service
{
    public class ManifestService:IManifestService
    {
        private readonly IManifestRepository _manifestRepository;
        private readonly IMasterFacilityRepository _masterFacilityRepository;
        private  readonly ILiveSyncService _liveSyncService;

        public ManifestService(IManifestRepository manifestRepository, ILiveSyncService liveSyncService, IMasterFacilityRepository masterFacilityRepository)
        {
            _manifestRepository = manifestRepository;
            _liveSyncService = liveSyncService;
            _masterFacilityRepository = masterFacilityRepository;
        }

        public void Process()
        {
            var manifests = _manifestRepository.GetStaged().ToList();
            if (manifests.Any())
            {
                _manifestRepository.ClearFacility(manifests);

                foreach (var manifest in manifests)
                {
                    var clientCount = _manifestRepository.GetPatientCount(manifest.Id);
                    _liveSyncService.SyncManifest(manifest,clientCount);

                    try
                    {
                        // Get MasterFacility
                        var masterFacility = _masterFacilityRepository.GetBySiteCode(manifest.SiteCode);

                        if (null != masterFacility)
                        {
                            // Sync Metrics
                            var metricDtos = MetricDto.Generate(masterFacility, manifest);
                            _liveSyncService.SyncMetrics(metricDtos);
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error(e.Message);
                    }

                }
            }
        }


    }
}
