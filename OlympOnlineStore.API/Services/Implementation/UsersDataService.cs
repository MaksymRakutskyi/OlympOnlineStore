using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OlympOnlineStore.API.Data;
using OlympOnlineStore.API.Data.Entities;
using OlympOnlineStore.API.Services.Interfaces;
using OlympOnlineStore.API.Utils;

namespace OlympOnlineStore.API.Services.Implementation;

public class UsersDataService(OlympOnlineStoreDbContext dbContext) : IUsersDataService
{
    public async Task<UserEntity?> Get(Guid userId)
    {
        return await dbContext.Users.FindAsync(userId);
    }

    public async Task<UserEntity?> GetByLogin(string login)
    {
        return await dbContext.Users.FirstOrDefaultAsync(x =>
            x.Email == login || x.PhoneNumber == login.ClearPhoneNumber());
    }

    public async Task<List<UserEntity>?> GetAll(Expression<Func<UserEntity, bool>>? predicate = null)
    {
        return await dbContext.Users.Where(predicate ?? (_ => true)).ToListAsync();
    }

    public async Task<bool> InsertOrUpdate(UserEntity user)
    {
        var existedUser = await dbContext.Users.FindAsync(user.UserId);
        if (existedUser is null)
            dbContext.Entry(user).State = EntityState.Added;
        else
            dbContext.Entry(existedUser).CurrentValues.SetValues(user);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Guid userId)
    {
        var existedUser = await dbContext.Users.FindAsync(userId);
        if (existedUser is null) return true;
        dbContext.Users.Remove(existedUser);
        return await dbContext.SaveChangesAsync() > 0;
    }
}