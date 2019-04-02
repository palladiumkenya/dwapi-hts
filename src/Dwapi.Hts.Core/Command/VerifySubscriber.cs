using Dwapi.Hts.SharedKernel.Model;
using MediatR;

namespace Dwapi.Hts.Core.Command
{
    public class VerifySubscriber : IRequest<VerificationResponse>
    {
        public string DocketId { get; set; }
        public string SubscriberId { get; }
        public string AuthToken { get; }

        public VerifySubscriber(string docketId, string subscriberId, string authToken)
        {
            DocketId = docketId;
            SubscriberId = subscriberId;
            AuthToken = authToken;
        }
    }
}