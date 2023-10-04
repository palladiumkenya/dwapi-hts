﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.Core.Interfaces.Service;
using Dwapi.Hts.SharedKernel.Custom;
using Dwapi.Hts.SharedKernel.Exceptions;
using Dwapi.Hts.SharedKernel.Model;
using Hangfire;
using Serilog;

namespace Dwapi.Hts.Core.Service
{
    public class HtsService : IHtsService
    {
        private readonly IHtsClientRepository _clientRepository;
        private readonly IHtsClientLinkageRepository _linkageRepository;
        private readonly IHtsClientPartnerRepository _partnerRepository;
        private readonly IFacilityRepository _facilityRepository;
        private readonly IManifestRepository _manifestRepository;


        private readonly IHtsClientTestsRepository _htsClientTestsRepository;
        private readonly IHtsClientTracingRepository _clientTracingRepository;
        private readonly IHtsPartnerNotificationServicesRepository _htsPartnerNotificationServicesRepository;
        private readonly IHtsPartnerTracingRepository _partnerTracingRepository;
        private readonly IHtsHtsTestKitsRepository _kitsRepository;
        private readonly IHtsEligibilityExtractRepository _HtsEligibilityExtractRepository;

        private readonly ILiveSyncService _syncService;

        private List<SiteProfile> _siteProfiles = new List<SiteProfile>();

        public HtsService(IHtsClientRepository clientRepository, IHtsClientLinkageRepository linkageRepository, IHtsClientPartnerRepository partnerRepository, 
            IFacilityRepository facilityRepository, IManifestRepository manifestRepository,IHtsClientTestsRepository htsClientTestsRepository, IHtsClientTracingRepository clientTracingRepository, 
            IHtsPartnerNotificationServicesRepository htsPartnerNotificationServicesRepository, IHtsPartnerTracingRepository partnerTracingRepository, 
            IHtsHtsTestKitsRepository kitsRepository, ILiveSyncService syncService, IHtsEligibilityExtractRepository HtsEligibilityExtractRepository)
        {
            _clientRepository = clientRepository;
            _linkageRepository = linkageRepository;
            _partnerRepository = partnerRepository;
            _facilityRepository = facilityRepository;
            _manifestRepository = manifestRepository;
            _htsClientTestsRepository = htsClientTestsRepository;
            _clientTracingRepository = clientTracingRepository;
            _htsPartnerNotificationServicesRepository = htsPartnerNotificationServicesRepository;
            _partnerTracingRepository = partnerTracingRepository;
            _kitsRepository = kitsRepository;
            _HtsEligibilityExtractRepository = HtsEligibilityExtractRepository;

            _syncService = syncService;
        }

        public void Process(IEnumerable<HtsClient> clients)
        {
           List<Guid> facilityIds=new List<Guid>();

            if(null==clients)
                return;
            if(!clients.Any())
                return;

            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();

            // check if version allowed to send
            // var DwapiVersionSending = _manifestRepository.GetDWAPIversionSending(clients.FirstOrDefault().SiteCode);
            // var ver = DwapiVersionSending;
            // if (DwapiVersionSending != "3.1.1.3")
            // {
            //     // throw new Exception($" ====> You're using DWAPI Version [{DwapiVersionSending}]. Older Versions of DWAPI are not allowed to send to NDWH. UPGRADE to the latest version and RETRY");
            //     throw new DwapiVersionNotAllowedException(DwapiVersionSending);
            // }

            var batch = new List<HtsClient>();
            int count = 0;

            foreach (var client in clients)
            {
                count++;
                try
                {
                    client.FacilityId = GetFacilityId(client.SiteCode);
                    client.UpdateRefId();
                    batch.Add(client);

                    facilityIds.Add(client.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {client.SiteCode}");
                }


                if (count == 1000)
                {
                    _clientRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<HtsClient>();
                }

            }

            if (batch.Any())
                _clientRepository.CreateBulk(batch);

            SyncClients(facilityIds);

        }

        public void Process(IEnumerable<HtsClientLinkage> linkages)
        {
            List<Guid> facilityIds=new List<Guid>();


            if(null==linkages)
                return;
            if(!linkages.Any())
                return;

            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();

            var batch = new List<HtsClientLinkage>();
            int count = 0;

            foreach (var linkage in linkages)
            {
                count++;
                try
                {
                    linkage.FacilityId = GetFacilityId(linkage.SiteCode);
                    linkage.UpdateRefId();
                    batch.Add(linkage);
                    facilityIds.Add(linkage.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {linkage.SiteCode}");
                }


                if (count == 1000)
                {
                    _linkageRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<HtsClientLinkage>();
                }

            }

            if (batch.Any())
                _linkageRepository.CreateBulk(batch);

            SyncClients(facilityIds);

        }

        public void Process(IEnumerable<HtsClientPartner> partners)
        {
            List<Guid> facilityIds=new List<Guid>();


            if(null==partners)
                return;
            if(!partners.Any())
                return;

            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();

            var batch = new List<HtsClientPartner>();
            int count = 0;

            foreach (var partner in partners)
            {
                count++;
                try
                {
                    partner.FacilityId = GetFacilityId(partner.SiteCode);
                    partner.UpdateRefId();
                    batch.Add(partner);
                    facilityIds.Add(partner.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {partner.SiteCode}");
                }


                if (count == 1000)
                {
                    _partnerRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<HtsClientPartner>();
                }

            }

            if (batch.Any())
                _partnerRepository.CreateBulk(batch);

            SyncClients(facilityIds);

        }

        public void Process(IEnumerable<HtsClientTests> clientTestses)
        {

            List<Guid> facilityIds=new List<Guid>();

            if(null==clientTestses)
                return;
            if(!clientTestses.Any())
                return;

            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();

            var batch = new List<HtsClientTests>();
            int count = 0;

            foreach (var partner in clientTestses)
            {
                count++;
                try
                {
                    partner.FacilityId = GetFacilityId(partner.SiteCode);
                    partner.UpdateRefId();
                    batch.Add(partner);

                    facilityIds.Add(partner.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {partner.SiteCode}");
                }


                if (count == 1000)
                {
                    _htsClientTestsRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<HtsClientTests>();
                }

            }

            if (batch.Any())
                _htsClientTestsRepository.CreateBulk(batch);

            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<HtsClientTracing> clientTracings)
        {

            List<Guid> facilityIds=new List<Guid>();

            if(null==clientTracings)
                return;
            if(!clientTracings.Any())
                return;

            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();

            var batch = new List<HtsClientTracing>();
            int count = 0;

            foreach (var partner in clientTracings)
            {
                count++;
                try
                {
                    partner.FacilityId = GetFacilityId(partner.SiteCode);
                    partner.UpdateRefId();
                    batch.Add(partner);
                    facilityIds.Add(partner.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {partner.SiteCode}");
                }


                if (count == 1000)
                {
                    _clientTracingRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<HtsClientTracing>();
                }

            }

            if (batch.Any())
                _clientTracingRepository.CreateBulk(batch);

            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<HtsPartnerNotificationServices> partners)
        {
            List<Guid> facilityIds=new List<Guid>();

            if(null==partners)
                return;
            if(!partners.Any())
                return;

            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();

            var batch = new List<HtsPartnerNotificationServices>();
            int count = 0;

            foreach (var partner in partners)
            {
                count++;
                try
                {
                    partner.FacilityId = GetFacilityId(partner.SiteCode);
                    partner.UpdateRefId();
                    batch.Add(partner);
                    facilityIds.Add(partner.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {partner.SiteCode}");
                }


                if (count == 1000)
                {
                    _htsPartnerNotificationServicesRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<HtsPartnerNotificationServices>();
                }

            }

            if (batch.Any())
                _htsPartnerNotificationServicesRepository.CreateBulk(batch);

            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<HtsPartnerTracing> partners)
        {
            List<Guid> facilityIds=new List<Guid>();

            if(null==partners)
                return;
            if(!partners.Any())
                return;

            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();

            var batch = new List<HtsPartnerTracing>();
            int count = 0;

            foreach (var partner in partners)
            {
                count++;
                try
                {
                    partner.FacilityId = GetFacilityId(partner.SiteCode);
                    partner.UpdateRefId();
                    batch.Add(partner);
                    facilityIds.Add(partner.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {partner.SiteCode}");
                }


                if (count == 1000)
                {
                    _partnerTracingRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<HtsPartnerTracing>();
                }

            }

            if (batch.Any())
                _partnerTracingRepository.CreateBulk(batch);

            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<HtsTestKits> kits)
        {
            List<Guid> facilityIds=new List<Guid>();

            if(null==kits)
                return;
            if(!kits.Any())
                return;

            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();

            var batch = new List<HtsTestKits>();
            int count = 0;

            foreach (var partner in kits)
            {
                count++;
                try
                {
                    partner.FacilityId = GetFacilityId(partner.SiteCode);
                    partner.UpdateRefId();
                    batch.Add(partner);
                    facilityIds.Add(partner.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {partner.SiteCode}");
                }


                if (count == 1000)
                {
                    _kitsRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<HtsTestKits>();
                }

            }

            if (batch.Any())
                _kitsRepository.CreateBulk(batch);

            SyncClients(facilityIds);
        }
        
        public void Process(IEnumerable<HtsEligibilityExtract> HtsEligibilityExtract)
        {
            List<Guid> facilityIds=new List<Guid>();

            if(null==HtsEligibilityExtract)
                return;
            if(!HtsEligibilityExtract.Any())
                return;

            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();

            var batch = new List<HtsEligibilityExtract>();
            int count = 0;

            foreach (var screening in HtsEligibilityExtract)
            {
                count++;
                try
                {
                    screening.FacilityId = GetFacilityId(screening.SiteCode);
                    batch.Add(screening);
                    facilityIds.Add(screening.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {screening.SiteCode}");
                }


                if (count == 1000)
                {
                    _HtsEligibilityExtractRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<HtsEligibilityExtract>();
                }

            }

            if (batch.Any())
                _HtsEligibilityExtractRepository.CreateBulk(batch);

            SyncClients(facilityIds);
        }

        public Guid GetFacilityId(int siteCode)
        {
            // // check if version allowed to send
            // var DwapiVersionSending = _manifestRepository.GetDWAPIversionSending(siteCode);
            // var ver = DwapiVersionSending;
            // if (DwapiVersionSending != "3.1.1.3")
            // {
            //     // throw new Exception($" ====> You're using DWAPI Version [{DwapiVersionSending}]. Older Versions of DWAPI are not allowed to send to NDWH. UPGRADE to the latest version and RETRY");
            //     throw new DwapiVersionNotAllowedException(DwapiVersionSending);
            // }
            
            var profile = _siteProfiles.FirstOrDefault(x => x.SiteCode == siteCode);
            if (null == profile)
                throw new FacilityNotFoundException(siteCode);

            return profile.FacilityId;
        }

        private void SyncClients(List<Guid> facIlds)
        {
            if (facIlds.Any())
            {
                _syncService.SyncStats(facIlds.Distinct().ToList());
            }
        }
    }
}
