using System.Linq.Expressions;
using OlympOnlineStore.API.Data.Entities;

namespace OlympOnlineStore.API.Services.Interfaces;

public interface IUsersDataService
{
    Task<UserEntity?> Get(Guid userId);
    Task<List<UserEntity>?> GetAll(Expression<Func<UserEntity, bool>>? predicate = null);
    Task<bool> InsertOrUpdate(UserEntity user);
    Task<bool> Delete(Guid userId);
}