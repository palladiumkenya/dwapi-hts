using System.Threading;
using System.Threading.Tasks;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.SharedKernel.Exceptions;
using MediatR;

namespace Dwapi.Hts.Core.CommandHandler
{
    public class ValidateFacilityKeyHandler: IRequestHandler<ValidateFacilityKey,bool>
    {
        private readonly IFacilityRepository _repository;

        public ValidateFacilityKeyHandler(IFacilityRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ValidateFacilityKey request, CancellationToken cancellationToken)
        {
            var masterFacility =await _repository.GetAsync(x=>x.Id==request.Key);

            if (null==masterFacility)
                throw new FacilityNotFoundException(request.Key);

            return true;
        }
    }
}