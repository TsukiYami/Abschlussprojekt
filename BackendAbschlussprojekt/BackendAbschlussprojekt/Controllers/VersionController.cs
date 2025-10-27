using BackendAbschlussprojekt.DB;
using BackendAbschlussprojekt.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
            if(!m_oVersionService.GetAll().IsNullOrEmpty())
            {
                m_oVersionService.GetAll();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateVersion(Version oVersion)
        {

            return BadRequest();
        }
    }
}
