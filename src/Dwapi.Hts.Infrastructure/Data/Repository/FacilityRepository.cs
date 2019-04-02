using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.SharedKernel.Infrastructure.Data;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Infrastructure.Data.Repository
{
    public class FacilityRepository : BaseRepository<Facility, Guid>, IFacilityRepository
    {
        public FacilityRepository(HtsContext context) : base(context)
        {
        }

        public IEnumerable<SiteProfile> GetSiteProfiles()
        {
            return GetAll().Select(x => new SiteProfile(x.SiteCode, x.Id));
        }

        public IEnumerable<SiteProfile> GetSiteProfiles(List<int> siteCodes)
        {
            return GetAll(x=>siteCodes.Contains(x.SiteCode)).Select(x => new SiteProfile(x.SiteCode, x.Id));
        }
    }
}