using WebApiExam.Core.Services;
using WebApiExam.Core.BusinessModels.Implementation;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace WebApiExam.Controllers
{
    [Authorize]
    [EnableCors("AllowSpecificOrigin")]
    [Produces("application/json")]
    [Route("api/Token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IAccountService _accountService;

        public TokenController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] UserLoginModel obj)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userVerified = await _accountService.VerifyUserAsync(obj);

            if (userVerified == null) return BadRequest(new ResponseModel { Status = false, Message = "Invalid user." });

            var token = _accountService.GenerateJwt(userVerified);

            return Ok(token);
        }
    }
}
