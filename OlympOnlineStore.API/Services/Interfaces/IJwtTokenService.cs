using OlympOnlineStore.API.Data.Entities;

namespace OlympOnlineStore.API.Services.Interfaces;

public interface IJwtTokenService
{
    string GenerateJwtToken(UserEntity user);
}