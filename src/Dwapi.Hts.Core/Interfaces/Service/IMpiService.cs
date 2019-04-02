using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;

namespace Dwapi.Hts.Core.Interfaces.Service
{
    public interface IMpiService
    {
        void Process(IEnumerable<HtsClient> masterPatientIndices);
    }
}