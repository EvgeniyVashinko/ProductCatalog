using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProductCatalog.Core.Services;
using ProductCatalog.Core.Requests.Account;
using Microsoft.AspNetCore.Authorization;

namespace ProductCatalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            var response = await _accountService.Login(request);

            if (response is not null)
            {
                return Ok(response);
            }

            return Unauthorized();
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequest request)
        {
            await _accountService.CreateUser(request);

            var response = await _accountService.Login(new()
            {
                Email = request.Email,
                Password = request.Password
            });

            return Ok(response);
        }

        [HttpPost("change-password")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            await _accountService.ChangePassword(request);

            return Ok();
        }
    }
}
