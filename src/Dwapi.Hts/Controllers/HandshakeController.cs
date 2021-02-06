using System;
using System.Threading.Tasks;
using Dwapi.Hts.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Dwapi.Hts.Controllers
{
    [Route("api/hts/[controller]")]
    [ApiController]
    public class HandshakeController : ControllerBase
    {
        private readonly IManifestRepository _manifestRepository;

        public HandshakeController(IManifestRepository manifestRepository)
        {
            _manifestRepository = manifestRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Verify(Guid session)
        {
            try
            {
                await _manifestRepository.EndSession(session);
                return Ok(session);
            }
            catch (Exception e)
            {
                Log.Error(e, "handshake error");
                return StatusCode(500, e.Message);
            }
        }
    }
}
