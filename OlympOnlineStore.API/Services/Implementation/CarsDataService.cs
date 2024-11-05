using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OlympOnlineStore.API.Data;
using OlympOnlineStore.API.Data.Entities;
using OlympOnlineStore.API.Services.Interfaces;

namespace OlympOnlineStore.API.Services.Implementation;

public class CarsDataService(OlympOnlineStoreDbContext dbContext) : ICarsDataService
{
    public async Task<CarEntity?> Get(Guid carId)
    {
        return await dbContext.Cars.Include(c => c.ImageEntities)
            .Include(c => c.BookingEntities)
            .ThenInclude(b => b.PaymentEntities)
            .FirstOrDefaultAsync(c => c.CarId == carId);
    }

    public async Task<List<CarEntity>?> GetAll(Expression<Func<CarEntity, bool>>? predicate = null)
    {
        return await dbContext.Cars.Where(predicate ?? (_ => true))
            .Include(c => c.ImageEntities)
            .Include(c => c.BookingEntities)
            .ThenInclude(b => b.PaymentEntities)
            .ToListAsync();
    }

    public async Task<bool> InsertOrUpdate(CarEntity car)
    {
        var existedCar = await dbContext.Cars.FindAsync(car.CarId);
        if (existedCar is null)
            dbContext.Entry(car).State = EntityState.Added;
        else
            dbContext.Entry(existedCar).CurrentValues.SetValues(car);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Guid carId)
    {
        var existedCar = await dbContext.Cars.FindAsync(carId);
        if (existedCar is null) return true;
        dbContext.Cars.Remove(existedCar);
        return await dbContext.SaveChangesAsync() > 0;
    }
}