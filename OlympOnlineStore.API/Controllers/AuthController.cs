using Microsoft.AspNetCore.Mvc;

namespace OlympOnlineStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(string login, string password)
    {
        return Ok();
    }
}