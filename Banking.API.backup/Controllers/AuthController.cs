using Banking.Application.Auth.Contracts;
using Banking.Application.Auth.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthApplicationService _authApplicationService;
        private readonly IAuthQueries _authQueries;

        public AuthController(IAuthApplicationService authApplicationService, IAuthQueries authQueries)
        {
            _authApplicationService = authApplicationService;
            _authQueries = authQueries;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            LoginResponseDto response = _authApplicationService.Login(loginDto);
            return StatusCode(response.HttpStatusCode, response.Response);
        }
    }
}