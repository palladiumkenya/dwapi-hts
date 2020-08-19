using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Exchange;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.SharedKernel.Infrastructure.Data;
using Dwapi.Hts.SharedKernel.Model;
using Serilog;

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

        public IEnumerable<StatsDto> GetFacStats(IEnumerable<Guid> facilityIds)
        {
            var list = new List<StatsDto>();
            foreach (var facilityId in facilityIds)
            {
                try
                {
                    var stat = GetFacStats(facilityId);
                    if(null!=stat)
                        list.Add(stat);
                }
                catch (Exception e)
                {
                    Log.Error(e.Message);
                }


            }
            return list;
        }

        public StatsDto GetFacStats(Guid facilityId)
        {
            string sql = $@"
select
(select top 1 SiteCode from Facilities where id='{facilityId}') FacilityCode,
(select ISNULL(max(DateCreated),GETDATE()) from Clients where facilityid='{facilityId}') Updated,
(select count(id) from Clients where facilityid='{facilityId}') HtsClientExtract,
(select count(id) from ClientLinkages where facilityid='{facilityId}') HtsClientLinkageExtract,
(select count(id) from HtsClientTests where facilityid='{facilityId}') HtsClientTestsExtract,
(select count(id) from HtsClientTracing where facilityid='{facilityId}') HtsClientTracingExtract,
(select count(id) from HtsPartnerNotificationServices where facilityid='{facilityId}') HtsPartnerNotificationServicesExtract,
(select count(id) from HtsPartnerTracings where facilityid='{facilityId}') HtsPartnerTracingExtract,
(select count(id) from HtsTestKits where facilityid='{facilityId}') HtsTestKitsExtract
                ";

            var result = GetDbConnection().Query<dynamic>(sql).FirstOrDefault();

            if (null != result)
            {
                var stats=new StatsDto(result.FacilityCode,result.Updated);
                stats.AddStats("HtsClientExtract",result.HtsClientExtract);
                stats.AddStats("HtsClientLinkageExtract",result.HtsClientLinkageExtract);
                stats.AddStats("HtsClientTestsExtract",result.HtsClientTestsExtract);
                stats.AddStats("HtsClientTracingExtract",result.HtsClientTracingExtract);
                stats.AddStats("HtsPartnerNotificationServicesExtract",result.HtsPartnerNotificationServicesExtract);
                stats.AddStats("HtsPartnerTracingExtract",result.HtsPartnerTracingExtract);
                stats.AddStats("HtsTestKitsExtract",result.HtsTestKitsExtract);

                return stats;
            }

            return null;
        }

        public Facility GetBySiteCode(int siteCode)
        {
            return DbSet.FirstOrDefault(x=>x.SiteCode==siteCode);
        }
    }
}
