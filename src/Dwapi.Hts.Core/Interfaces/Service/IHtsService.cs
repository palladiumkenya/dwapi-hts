using System.Collections.Generic;
using Dwapi.Hts.Core.Domain;

namespace Dwapi.Hts.Core.Interfaces.Service
{
    public interface IHtsService
    {
        void Process(IEnumerable<HtsClient> clients);
        void Process(IEnumerable<HtsClientLinkage> linkages);
        void Process(IEnumerable<HtsClientPartner> partners);


        void Process(IEnumerable<HtsClientTests> clientTestses);
        void Process(IEnumerable<HtsClientTracing> clientTracings);
        void Process(IEnumerable<HtsPartnerNotificationServices> partnerNotification);
        void Process(IEnumerable<HtsPartnerTracing> partnerTracings);
        void Process(IEnumerable<HtsTestKits> kits);
        void Process(IEnumerable<HtsEligibilityExtract> htsEligibility);
        void Process(IEnumerable<HtsRiskScores> htsRiskScores);

    }
}
