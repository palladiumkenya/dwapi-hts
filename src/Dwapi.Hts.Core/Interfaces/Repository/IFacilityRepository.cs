using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.SharedKernel.Interfaces;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.Core.Interfaces.Repository
{
    public interface IFacilityRepository : IRepository<Facility, Guid>
    {
        IEnumerable<SiteProfile> GetSiteProfiles();
        IEnumerable<SiteProfile> GetSiteProfiles(List<int> siteCodes);
    }
}