using System.Linq.Expressions;
using OlympOnlineStore.API.Data.Entities;

namespace OlympOnlineStore.API.Services.Interfaces;

public interface ICarsDataService
{
    Task<CarEntity?> Get(Guid carId);
    Task<List<CarEntity>?> GetAll(Expression<Func<CarEntity, bool>>? predicate = null);
    Task<bool> InsertOrUpdate(CarEntity car);
    Task<bool> Delete(Guid carId);
}