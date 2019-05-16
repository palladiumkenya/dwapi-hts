using System;
using System.Threading.Tasks;
using Dwapi.Hts.Core.Command;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.Core.Interfaces.Service;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Dwapi.Hts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HtsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IManifestService _manifestService;
        private readonly IHtsService _htsService;
        private readonly IHtsClientRepository _htsClientRepository;

        public HtsController(IMediator mediator, IManifestRepository manifestRepository, IHtsClientRepository htsClientRepository, IManifestService manifestService, IHtsService htsService)
        {
            _mediator = mediator;
            _htsClientRepository = htsClientRepository;
            _manifestService = manifestService;
            _htsService = htsService;
        }

        // POST api/cbs/verify
        [HttpPost("Verify")]
        public async Task<IActionResult> Verify([FromBody] VerifySubscriber subscriber)
        {
            if (null == subscriber)
                return BadRequest();

            try
            {
                var dockect = await _mediator.Send(subscriber, HttpContext.RequestAborted);
                return Ok(dockect);
            }
            catch (Exception e)
            {
                Log.Error(e, "verify error");
                return StatusCode(500, e.Message);
            }
        }

        // POST api/cbs/Manifest
        [HttpPost("Manifest")]
        public async Task<IActionResult> ProcessManifest([FromBody] SaveManifest manifest)
        {
            if (null == manifest)
                return BadRequest();

            try
            {
                var faciliyKey = await _mediator.Send(manifest, HttpContext.RequestAborted);
                BackgroundJob.Enqueue(() => _manifestService.Process());
                return Ok(new
                {
                    FacilityKey = faciliyKey
                });
            }
            catch (Exception e)
            {
                Log.Error(e, "manifest error");
                return StatusCode(500, e.Message);
            }
        }

        // POST api/cbs/Mpi
        [HttpPost("Clients")]
        public IActionResult ProcessClient([FromBody] SaveClient client)
        {
            if (null == client)
                return BadRequest();

            try
            {
                var id=  BackgroundJob.Enqueue(() => _htsService.Process(client.Clients));
                return Ok(new
                {
                    BatchKey = id
                });
            }
            catch (Exception e)
            {
                Log.Error(e, "manifest error");
                return StatusCode(500, e.Message);
            }
        }

        // POST api/cbs/Mpi
        [HttpPost("Linkages")]
        public IActionResult ProcessLinkages([FromBody] SaveLinkage client)
        {
            if (null == client)
                return BadRequest();

            try
            {
                var id=  BackgroundJob.Enqueue(() => _htsService.Process(client.Linkages));
                return Ok(new
                {
                    BatchKey = id
                });
            }
            catch (Exception e)
            {
                Log.Error(e, "manifest error");
                return StatusCode(500, e.Message);
            }
        }

        // POST api/cbs/Mpi
        [HttpPost("Partners")]
        public IActionResult ProcessPartners([FromBody] SavePartner client)
        {
            if (null == client)
                return BadRequest();

            try
            {
                var id=  BackgroundJob.Enqueue(() => _htsService.Process(client.Partners));
                return Ok(new
                {
                    BatchKey = id
                });
            }
            catch (Exception e)
            {
                Log.Error(e, "manifest error");
                return StatusCode(500, e.Message);
            }
        }
    }
}
