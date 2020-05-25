using WebApiExam.Core.Services;
using WebApiExam.Core.BusinessModels.Contract;
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
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        private IResponseModel _response;

        public AccountController(
            IAccountService accountService,
            IResponseModel response)
        {
            _accountService = accountService;
            _response = response;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Create([FromBody] UserRegisterModel obj)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isRegistered = await _accountService.RegisterUserAsync(obj);

            _response.Status = isRegistered.Status;
            _response.Message = isRegistered.Message;

            if (_response.Status)
                return Ok(_response);
            else
                return BadRequest(_response);
        }
    }
}
