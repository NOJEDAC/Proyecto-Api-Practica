using Banking.Application.Users.Contracts;
using Banking.Application.Users.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("v1/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;

        public UsersController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [HttpPost]
        public IActionResult Register([FromBody] NewUserDto newUserDto)
        {
            NewUserResponseDto response = _userApplicationService.Register(newUserDto);
            return StatusCode(response.HttpStatusCode, response.Response);
        }
    }
}
