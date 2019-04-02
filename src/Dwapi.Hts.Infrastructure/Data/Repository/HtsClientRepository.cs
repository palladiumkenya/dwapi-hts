using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.SharedKernel.Infrastructure.Data;

namespace Dwapi.Hts.Infrastructure.Data.Repository
{
    public class HtsClientRepository : BaseRepository<HtsClient,Guid>, IHtsClientRepository
    {
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
    }
}
