using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OlympOnlineStore.API.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("[controller]")]
public class TestController : Controller
{
    [Authorize]
    [HttpGet("Get")]
    public ActionResult<string> Get()
    {
        return Ok("Test");
    }
}