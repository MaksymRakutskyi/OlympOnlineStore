using System.Text;
using Microsoft.AspNetCore.Mvc;
using OlympOnlineStore.API.Services.Interfaces;
using OlympOnlineStore.Models.Models;

namespace OlympOnlineStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IUsersDataService usersDataService, IJwtTokenService jwtTokenService) : ControllerBase
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        var user = await usersDataService.GetByLogin(loginModel.Login);
        if (user is null) 
            return BadRequest("Invalid login");
        
        if (loginModel.Password != Encoding.UTF8.GetString(user.PasswordHash))
            return BadRequest("Invalid password");
        
        return Ok(jwtTokenService.GenerateJwtToken(user));
    }
}