using System;
using System.Threading;
using System.Threading.Tasks;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.Domain;
using Dwapi.Hts.Core.Interfaces.Repository;
using MediatR;
using Serilog;

namespace Dwapi.Hts.Core.CommandHandler
{
    public class SaveManifestHandler : IRequestHandler<SaveManifest, MasterFacility>

    {
        private readonly IMediator _mediator;
        private readonly IManifestRepository _repository;
        private readonly IHtsClientRepository _htsClientRepository;
        private readonly IFacilityRepository _facilityRepository;

       
        public SaveManifestHandler(IMediator mediator, IManifestRepository repository,IHtsClientRepository htsClientRepository,IFacilityRepository facilityRepository)
        {
            _mediator = mediator;
            _repository = repository;
            _htsClientRepository = htsClientRepository;
            _facilityRepository = facilityRepository;
        }


        public async Task<MasterFacility> Handle(SaveManifest request, CancellationToken cancellationToken)
        {
            // var facilityId = await _mediator.Send(new EnrollFacility(request.Manifest.SiteCode,request.Manifest.Name,request.Manifest.EmrName), cancellationToken);
            //
            // request.Manifest.UpdateFacility(facilityId);
            // _repository.Create(request.Manifest);
            // await _repository.SaveAsync();
            //
            //
            // return request.Manifest.Id;
            
            var manifest = request.Manifest;
            
            try
            {
                manifest.Validate();
            
                var masterFacility = await _repository.VerifyFacility(manifest.SiteCode);
                if (null == masterFacility)
                    throw new Exception($"SiteCode [{manifest.SiteCode}] NOT FOUND in Master Facility List");
            
                // _facilityRepository.Enroll(masterFacility, manifest.EmrName, request.AllowSnapshot);
                var facilityId = await _mediator.Send(new EnrollFacility(request.Manifest.SiteCode,request.Manifest.Name,request.Manifest.EmrName), cancellationToken);

                return masterFacility;
            }
            catch (Exception e)
            {
                Log.Error(e, "Error at save manifest");
                throw;
            }
        }
    }
}
