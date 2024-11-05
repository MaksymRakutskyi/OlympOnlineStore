using Microsoft.EntityFrameworkCore;
using OlympOnlineStore.API.Data;
using OlympOnlineStore.API.Data.Entities;
using OlympOnlineStore.Models.Enums;

namespace OlympOnlineStore.API.Utils;

public static class DataHelper
{
    public static void SeedDatabase(OlympOnlineStoreDbContext dbContext)
    {
        SeedUsers(dbContext);
    }

    private static void SeedUsers(OlympOnlineStoreDbContext dbContext)
    {
        if (dbContext.Users.Any(x => x.Role == UserRoleType.Admin))
            return;

        dbContext.Add(new UserEntity
        {
            FirstName = "Admin",
            LastName = "Admin",
            Email = "admin@gmail.com",
            PhoneNumber = "012345678910",
            PasswordHash = "1"u8.ToArray(),
            PasswordSalt = "1"u8.ToArray(),
            Role = UserRoleType.Admin,
            CreatedAt = DateTime.Now
        });
    }
}