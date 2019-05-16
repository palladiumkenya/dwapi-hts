using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.SharedKernel.Infrastructure.Data;

namespace Dwapi.Hts.Infrastructure.Data.Repository
{
    public class HtsClientPartnerRepository : BaseRepository<HtsClientPartner,Guid>, IHtsClientPartnerRepository
    {
        public HtsClientPartnerRepository(HtsContext context) : base(context)
        {
        }

        public void Process(Guid facilityId,IEnumerable<HtsClientPartner> clients)
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