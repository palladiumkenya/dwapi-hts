using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.SharedKernel.Infrastructure.Data;

namespace Dwapi.Hts.Infrastructure.Data.Repository
{
    public class HtsHtsTestKitsRepository : BaseRepository<HtsTestKits,Guid>, IHtsHtsTestKitsRepository
    {
        public HtsHtsTestKitsRepository(HtsContext context) : base(context)
        {
        }

        public void Process(Guid facilityId,IEnumerable<HtsTestKits> clients)
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