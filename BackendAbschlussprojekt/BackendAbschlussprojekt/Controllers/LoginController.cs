using BackendAbschlussprojekt.DB;
using BackendAbschlussprojekt.Services;
using Entity.DTOs.Post;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendAbschlussprojekt.Controllers
{
    [Route("/api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService m_oLoginService;

        public LoginController(AufraumaktionContext oContext)
        {
            m_oLoginService = new LoginService(oContext);
        }

        [HttpPost("RegisterUser")]
        public IActionResult Register(LoginPostDTO oLoginPostDTO)
        {
            string sHeaderBody = Request.Headers[RequestValues.HEADER_BODY];
            LoginPostDTO oDTO = JsonConvert.DeserializeObject<LoginPostDTO>(sHeaderBody);

            if (m_oLoginService.Post(oLoginPostDTO))
                return Created();

            return BadRequest();
        }

        [HttpGet("Login")]
        public IActionResult Login(string sUsername, string sPassword)
        {
            sUsername = Request.Headers[RequestValues.HEADER_USERNAME];
            sPassword = Request.Headers[RequestValues.HEADER_PASSWORD];

            if (string.IsNullOrEmpty(sUsername) || string.IsNullOrEmpty(sPassword))
                return BadRequest();

            (bool, Guid?) LoginInfo = m_oLoginService.LogIn(sUsername, sPassword);
            if (LoginInfo.Item1)
            {
                return Ok(LoginInfo.Item2);
            }

            return BadRequest();
        }
    }
}
