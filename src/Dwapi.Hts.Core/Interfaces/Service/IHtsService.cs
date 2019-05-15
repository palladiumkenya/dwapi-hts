using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;

namespace Dwapi.Hts.Core.Interfaces.Service
{
    public interface IHtsService
    {
        void Process(IEnumerable<HtsClient> clients);
        void Process(IEnumerable<HtsClientLinkage> linkages);
        void Process(IEnumerable<HtsClientPartner> partners);
    }
}
