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
        private List<SiteProfile> _siteProfiles = new List<SiteProfile>();

        public HtsService(IHtsClientRepository clientRepository, IHtsClientLinkageRepository linkageRepository, IHtsClientPartnerRepository partnerRepository, IFacilityRepository facilityRepository)
        {
            _clientRepository = clientRepository;
            _linkageRepository = linkageRepository;
            _partnerRepository = partnerRepository;
            _facilityRepository = facilityRepository;
        }

        public void Process(IEnumerable<HtsClient> clients)
        {
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



        }

        public void Process(IEnumerable<HtsClientLinkage> linkages)
        {
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

        }

        public void Process(IEnumerable<HtsClientPartner> partners)
        {
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

        }

        public Guid GetFacilityId(int siteCode)
        {
            var profile = _siteProfiles.FirstOrDefault(x => x.SiteCode == siteCode);
            if (null == profile)
                throw new FacilityNotFoundException(siteCode);

            return profile.FacilityId;
        }
    }
}
