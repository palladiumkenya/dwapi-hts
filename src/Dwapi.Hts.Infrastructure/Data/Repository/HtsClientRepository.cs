using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.SharedKernel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Dwapi.Hts.Infrastructure.Data.Repository
{
    public class HtsClientRepository : BaseRepository<HtsClient,Guid>, IHtsClientRepository
    {
        private readonly HtsContext context;

        public HtsClientRepository(HtsContext context) : base(context)
        {
        }

        public void Process(Guid facilityId,IEnumerable<HtsClient> clients)
        {
            var mpi = clients.ToList();

            if (mpi.Any())
            {
                mpi.ForEach(x => x.FacilityId = facilityId);
                CreateBulk(mpi);
            }
        }
        
        
        // public Task<MasterFacility> VerifyFacility(int siteCode)
        // {
        //     int originalSiteCode = siteCode;
        //
        //     string fcode = siteCode.ToString();
        //     if (fcode.Length != 5)
        //     {
        //         Log.Debug(new string('^', 40));
        //         Log.Debug($"Invalid SiteCode:{siteCode}");
        //         
        //         Log.Debug(new string('^', 40));
        //     }
        //
        //     return context.MasterFacilities
        //         .AsNoTracking()
        //         .FirstOrDefaultAsync(x => x.Id == siteCode);
        // }
        
    }
}
