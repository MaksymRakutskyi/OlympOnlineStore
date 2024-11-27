using System.Linq.Expressions;
using OlympOnlineStore.API.Data.Entities;

namespace OlympOnlineStore.API.Services.Interfaces;

public interface ICarImagesDataService
{
    Task<CarImageEntity?> Get(Guid carImageId);
    Task<List<CarImageEntity>?> GetAll(Expression<Func<CarImageEntity, bool>>? predicate = null);
    Task<bool> InsertOrUpdate(CarImageEntity carImage);
    Task<bool> Delete(Guid carImageId);
}