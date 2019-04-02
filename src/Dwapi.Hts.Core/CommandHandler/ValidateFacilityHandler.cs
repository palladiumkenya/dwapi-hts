using System.Threading;
using System.Threading.Tasks;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.SharedKernel.Exceptions;
using MediatR;

namespace Dwapi.Hts.Core.CommandHandler
{
    public class ValidateFacilityHandler: IRequestHandler<ValidateFacility,MasterFacility>
    {
        private readonly IMasterFacilityRepository _repository;

        public ValidateFacilityHandler(IMasterFacilityRepository repository)
        {
            _repository = repository;
        }

        public async Task<MasterFacility> Handle(ValidateFacility request, CancellationToken cancellationToken)
        {
            var masterFacility =await _repository.GetAsync(request.SiteCode);

            if (null==masterFacility)
                throw new FacilityNotFoundException(request.SiteCode);

            return masterFacility;
        }
    }
}