using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OlympOnlineStore.API.Data.Entities;
using OlympOnlineStore.API.Services.Interfaces;

namespace OlympOnlineStore.API.Services.Implementation;

public class JwtTokenService(IConfiguration configuration) : IJwtTokenService
{
    public string GenerateJwtToken(UserEntity user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}".Trim()),
            new(ClaimTypes.Role, user.Role.ToString())
        };
        var expires = DateTime.UtcNow.AddHours(12);
        
        var token = new JwtSecurityToken(claims: claims, expires: expires, signingCredentials: credentials);
        
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
}