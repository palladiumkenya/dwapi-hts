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
    public class MasterPatientIndexRepository : BaseRepository<MasterPatientIndex,Guid>, IMasterPatientIndexRepository
    {
        public MasterPatientIndexRepository(HtsContext context) : base(context)
        {
        }

        public void Process(Guid facilityId,IEnumerable<MasterPatientIndex> masterPatientIndices)
        {
            var mpi = masterPatientIndices.ToList();

            if (mpi.Any())
            {
                mpi.ForEach(x => x.FacilityId = facilityId);
                CreateBulk(mpi);
            }
        }
    }
}
