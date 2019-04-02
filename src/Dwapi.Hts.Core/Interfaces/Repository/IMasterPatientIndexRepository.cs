using System;
using System.Collections.Generic;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.SharedKernel.Interfaces;

namespace Dwapi.Hts.Core.Interfaces.Repository
{
    public interface IMasterPatientIndexRepository : IRepository<MasterPatientIndex,Guid>
    {
        void Process(Guid facilityId,IEnumerable<MasterPatientIndex> masterPatientIndices);
    }
}
