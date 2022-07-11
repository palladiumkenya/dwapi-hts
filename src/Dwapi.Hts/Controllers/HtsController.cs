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

        // POST api/Hts/verify
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

        // POST api/Hts/Manifest
        [HttpPost("Manifest")]
        public async Task<IActionResult> ProcessManifest([FromBody] SaveManifest manifest)
        {
            if (null == manifest)
                return BadRequest();

            try
            {
                manifest.AllowSnapshot = Startup.AllowSnapshot;
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

        // POST api/Hts/Clients
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

        // POST api/Hts/Linkages
        [HttpPost("Linkages")]
        public IActionResult ProcessLinkages([FromBody] SaveLinkage client)
        {
            if (null == client)
                return BadRequest();

            try
            {
                var id=  BackgroundJob.Enqueue(() => _htsService.Process(client.ClientLinkage));
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

        // POST api/Hts/Partners
        [HttpPost("Partners")]
        public IActionResult ProcessPartners([FromBody] SavePartner client)
        {
            if (null == client)
                return BadRequest();

            try
            {
                var id=  BackgroundJob.Enqueue(() => _htsService.Process(client.ClientPartners));
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
        // POST api/Hts/HtsClientTests
        [HttpPost("HtsClientTests")]
        public IActionResult ProcessTests([FromBody] SaveClientTests client)
        {
            if (null == client)
                return BadRequest();

            try
            {
                var id=  BackgroundJob.Enqueue(() => _htsService.Process(client.ClientTests));
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
        // POST api/Hts/HtsClientTracings
        [HttpPost("HtsClientTracings")]
        public IActionResult ProcessTracings([FromBody] SaveClientTracings client)
        {
            if (null == client)
                return BadRequest();

            try
            {
                var id=  BackgroundJob.Enqueue(() => _htsService.Process(client.ClientTracing));
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
        // POST api/Hts/Pns
        [HttpPost("Pns")]
        public IActionResult ProcessPns([FromBody] SavePns client)
        {
            if (null == client)
                return BadRequest();

            try
            {
                var id=  BackgroundJob.Enqueue(() => _htsService.Process(client.PartnerNotificationServices));
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
        // POST api/Hts/HtsPartnerTracings
        [HttpPost("HtsPartnerTracings")]
        public IActionResult ProcessTracings([FromBody] SavePartnerTracing client)
        {
            if (null == client)
                return BadRequest();

            try
            {
                var id=  BackgroundJob.Enqueue(() => _htsService.Process(client.PartnerTracing));
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

        // POST api/Hts/HtsTestKits
        [HttpPost("HtsTestKits")]
        public IActionResult ProcessKits([FromBody] SaveKits client)
        {
            if (null == client)
                return BadRequest();

            try
            {
                var id=  BackgroundJob.Enqueue(() => _htsService.Process(client.TestKits));
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
        // POST api/Hts/HtsEligibility
        [HttpPost("HtsEligibilityScreening")]
        public IActionResult ProcessHtsEligibility([FromBody] SaveHtsEligibility client)
        {
            if (null == client)
                return BadRequest();

            try
            {
                var id=  BackgroundJob.Enqueue(() => _htsService.Process(client.HtsEligibility));
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
