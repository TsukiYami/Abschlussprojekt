using BackendAbschlussprojekt.DB;
using BackendAbschlussprojekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendAbschlussprojekt.Controllers
{
    [Route("/api/")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private VersionService m_oVersionService;

        public VersionController(AufraumaktionContext oContext)
        {
            m_oVersionService = new VersionService(oContext);
        }

        [HttpGet]
        public IActionResult GetAllVersions()
        {

        }
    }
}
