using System;
using System.Linq;
using System.Threading.Tasks;
using Dwapi.Hts.Core.Interfaces.Repository;
using Dwapi.Hts.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Dwapi.Hts.Controllers
{
    [Route("api/Hts/[controller]")]
    public class HandshakeController : Controller
    {
        private readonly IManifestRepository _manifestRepository;
        private readonly ILiveSyncService _liveSyncService;

        public HandshakeController(IManifestRepository manifestRepository, ILiveSyncService liveSyncService)
        {
            _manifestRepository = manifestRepository;
            _liveSyncService = liveSyncService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid session)
        {
            try
            {
                var sess = session.ToString();
                Console.WriteLine("writeline GetSessionHandshakes ===========>"+sess);
                await _manifestRepository.EndSession(session);
                var handshakes = _manifestRepository
                    .GetSessionHandshakes(session)
                    .ToList();
                await _liveSyncService.SyncHandshake(handshakes);
                return Ok(session);
            }
            catch (Exception e)
            {
                var sess = session.ToString();
                Console.WriteLine("error in session ===========>"+sess);
                Log.Error(e, "handshake error");
                return StatusCode(500, e.Message);
            }
        }
    }
}