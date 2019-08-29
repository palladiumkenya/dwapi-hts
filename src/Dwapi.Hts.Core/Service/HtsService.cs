using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.Core.Interfaces.Service;
using Dwapi.Hts.SharedKernel.Exceptions;
using Dwapi.Hts.SharedKernel.Model;
using Serilog;

namespace Dwapi.Hts.Core.Service
{
    public class HtsService : IHtsService
    {
        private readonly IHtsClientRepository _clientRepository;
        private readonly IHtsClientLinkageRepository _linkageRepository;
        private readonly IHtsClientPartnerRepository _partnerRepository;
        private readonly IFacilityRepository _facilityRepository;


        private readonly IHtsClientTestsRepository _htsClientTestsRepository;
        private readonly IHtsClientTracingRepository _clientTracingRepository;
        private readonly IHtsPartnerNotificationServicesRepository _htsPartnerNotificationServicesRepository;
        private readonly IHtsPartnerTracingRepository _partnerTracingRepository;
        private readonly IHtsHtsTestKitsRepository _kitsRepository;
        private readonly ILiveSyncService _syncService;

        private List<SiteProfile> _siteProfiles = new List<SiteProfile>();

        public HtsService(IHtsClientRepository clientRepository, IHtsClientLinkageRepository linkageRepository, IHtsClientPartnerRepository partnerRepository, IFacilityRepository facilityRepository, IHtsClientTestsRepository htsClientTestsRepository, IHtsClientTracingRepository clientTracingRepository, IHtsPartnerNotificationServicesRepository htsPartnerNotificationServicesRepository, IHtsPartnerTracingRepository partnerTracingRepository, IHtsHtsTestKitsRepository kitsRepository, ILiveSyncService syncService)
        {
            _clientRepository = clientRepository;
            _linkageRepository = linkageRepository;
            _partnerRepository = partnerRepository;
            _facilityRepository = facilityRepository;
            _htsClientTestsRepository = htsClientTestsRepository;
            _clientTracingRepository = clientTracingRepository;
            _htsPartnerNotificationServicesRepository = htsPartnerNotificationServicesRepository;
            _partnerTracingRepository = partnerTracingRepository;
            _kitsRepository = kitsRepository;
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

            var batch = new List<HtsClient>();
            int count = 0;

            foreach (var client in clients)
            {
                try
                {
                    client.FacilityId = GetFacilityId(client.SiteCode);
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
                try
                {
                    linkage.FacilityId = GetFacilityId(linkage.SiteCode);
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
                try
                {
                    partner.FacilityId = GetFacilityId(partner.SiteCode);
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
                try
                {
                    partner.FacilityId = GetFacilityId(partner.SiteCode);
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
                try
                {
                    partner.FacilityId = GetFacilityId(partner.SiteCode);
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
                try
                {
                    partner.FacilityId = GetFacilityId(partner.SiteCode);
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
                try
                {
                    partner.FacilityId = GetFacilityId(partner.SiteCode);
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
                try
                {
                    partner.FacilityId = GetFacilityId(partner.SiteCode);
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

        public Guid GetFacilityId(int siteCode)
        {
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
