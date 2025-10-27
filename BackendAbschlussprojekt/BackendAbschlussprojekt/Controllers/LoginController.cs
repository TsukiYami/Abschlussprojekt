using BackendAbschlussprojekt.DB;
using BackendAbschlussprojekt.Services;
using Entity.DTOs.Post;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BackendAbschlussprojekt.Caches;
using Entity.Entities;

namespace BackendAbschlussprojekt.Controllers
{
    [Route("/api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService m_oLoginService;

        public LoginController(AufraumaktionContext oContext)
        {
            m_oLoginService = new LoginService(oContext);
        }

        [HttpPost("RegisterUser")]
        public IActionResult Register([FromBody] LoginPostDTO oLoginPostDTO)
        {
            if (oLoginPostDTO == null)
                return BadRequest();

            if (m_oLoginService.Post(oLoginPostDTO))
                return Created(string.Empty, oLoginPostDTO);

            return BadRequest();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginPostDTO oLoginPostDTO)
        {
            if (oLoginPostDTO == null
                || string.IsNullOrEmpty(oLoginPostDTO.sUsername)
                || string.IsNullOrEmpty(oLoginPostDTO.sPassword))
            {
                return BadRequest();
            }

            (bool bSuccess, Guid? oSessionId) loginResult = m_oLoginService.LogIn(oLoginPostDTO.sUsername, oLoginPostDTO.sPassword);

            if (loginResult.bSuccess)
                return Ok(loginResult.oSessionId);

            return Unauthorized();
        }

        [HttpPost("LogoutUser")]
        public IActionResult Logout()
        {
            if (!Request.Headers.TryGetValue(RequestValues.HEADER_GUID, out var headerValue) || string.IsNullOrEmpty(headerValue))
                return BadRequest();

            if (!Guid.TryParse(headerValue, out var sSessiontoken))
                return BadRequest();

            UserCache.RemoveLoginFromCache(sSessiontoken);

            return Ok();
        }

        [HttpDelete("DeleteUser/{nID}")]
        public IActionResult DeleteUser(long nID)
        {
            LoginEntity oEntity = m_oLoginService.GetByID(nID);
            if (oEntity == null)
                return NotFound();

            // If a delete method exists on the service, call it here (e.g. m_oLoginService.Delete(nID));
            return Ok(oEntity);
        }
    }
}