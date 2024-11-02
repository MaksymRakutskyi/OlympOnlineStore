using Microsoft.EntityFrameworkCore;
using OlympOnlineStore.API.Data;
using OlympOnlineStore.API.Data.Entities;
using OlympOnlineStore.API.Services.Implementation;
using OlympOnlineStore.Models.Enums;

namespace OlympOnlineStore.API.Utils;

public static class DataHelper
{
    public static void MigrateDatabase(IConfiguration config)
    {
        //using var dbContext = new OlympOnlineStoreDbContext(config);
        //dbContext.Database.Migrate();
    }

    public static void SeedDatabase(IConfiguration config)
    {
        //using var dbContext = new OlympOnlineStoreDbContext(config);
        //dbContext.Database.EnsureCreated();
        
        //SeedUsers(dbContext);
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
            PasswordHash = "1",
            PasswordSalt = "1",
            Role = UserRoleType.Admin,
            CreatedAt = DateTime.Now
        });
    }
}