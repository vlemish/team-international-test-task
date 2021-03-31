using Microsoft.AspNetCore.Mvc;
using TeamInternationalTestWebApi.Models;
using TeamInternationalTestWebApi.Services;

namespace TeamInternationalTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;


        public AccountController(IUserService repo)
        {
            _userService = repo;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(response);
        }

    }
}
