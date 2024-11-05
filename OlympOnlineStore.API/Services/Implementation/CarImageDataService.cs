using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OlympOnlineStore.API.Data;
using OlympOnlineStore.API.Data.Entities;
using OlympOnlineStore.API.Services.Interfaces;

namespace OlympOnlineStore.API.Services.Implementation;

public class CarImageDataService(OlympOnlineStoreDbContext dbContext) : ICarImageDataService
{
    public async Task<CarImageEntity?> Get(Guid carImageId)
    {
        return await dbContext.CarImages.FindAsync(carImageId);
    }

    public async Task<List<CarImageEntity>?> GetAll(Expression<Func<CarImageEntity, bool>>? predicate = null)
    {
        return await dbContext.CarImages.Where(predicate ?? (_ => true)).ToListAsync();
    }

    public async Task<bool> InsertOrUpdate(CarImageEntity carImage)
    {
        var existedCarImage = await dbContext.CarImages.FindAsync(carImage.ImageId);
        if (existedCarImage == null)
            dbContext.Entry(carImage).State = EntityState.Added;
        else
            dbContext.Entry(carImage).CurrentValues.SetValues(carImage);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Guid carImageId)
    {
        var existedCarImage = await dbContext.CarImages.FindAsync(carImageId);
        if (existedCarImage == null) return true;
        dbContext.CarImages.Remove(existedCarImage);
        return await dbContext.SaveChangesAsync() > 0;
    }
}