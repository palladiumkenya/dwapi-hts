using System.Threading;
using System.Threading.Tasks;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.SharedKernel.Exceptions;
using Dwapi.Hts.SharedKernel.Model;
using MediatR;

namespace Dwapi.Hts.Core.CommandHandler
{
    public class VerifySubscriberHandler : IRequestHandler<VerifySubscriber, VerificationResponse>
    {
        private readonly IDocketRepository _repository;

        public VerifySubscriberHandler(IDocketRepository repository)
        {
            _repository = repository;
        }


        public async Task<VerificationResponse> Handle(VerifySubscriber request, CancellationToken cancellationToken)
        {
            var docket = await _repository.FindAsync(request.DocketId);

            if (null == docket)
                throw new DocketNotFoundException(request.DocketId);

            if (!docket.SubscriberExists(request.SubscriberId))
                throw new SubscriberNotFoundException(request.SubscriberId);

            if (docket.SubscriberAuthorized(request.SubscriberId, request.AuthToken))
                    return new VerificationResponse(docket.Name,true);

            throw new SubscriberNotAuthorizedException(request.SubscriberId);
        }
    }
}