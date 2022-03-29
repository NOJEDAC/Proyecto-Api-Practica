using Microsoft.AspNetCore.Mvc;
using Common;

namespace Banking.API.Controllers
{
    [Produces("application/json")]
    [Route("")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            return new ApiStringResponse("api root endpoint");
        }
    }
}
