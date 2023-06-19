using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Dwapi.Hts.Core.Domain.Dto;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.Core.Interfaces.Service;
using Dwapi.Hts.SharedKernel.Enums;
using Hangfire;
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

        [Queue("manifest")]
        [AutomaticRetry(Attempts = 3)]
        [DisplayName("{0}")]
        public void Process(int siteCode)
        {
            var manifests = _manifestRepository.GetStaged(siteCode).ToList();
            if (manifests.Any())
            {
                var communityManifests = manifests.Where(x => x.EmrSetup == EmrSetup.Community).ToList();

                var otherManifests = manifests.Where(x => x.EmrSetup != EmrSetup.Community).ToList();

                try
                {
                    if (otherManifests.Any())
                        _manifestRepository.ClearFacility(otherManifests);
                }
                catch (Exception e)
                {
                    Log.Error("Clear MANIFEST ERROR ", e);
                }

                try
                {
                        // TODO: Check DREAMS sites
                    if (communityManifests.Any())
                        _manifestRepository.ClearFacility(communityManifests, "IRDO");
                }
                catch (Exception e)
                {
                    Log.Error("Clear COMMUNITY MANIFEST ERROR ", e);
                }

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
