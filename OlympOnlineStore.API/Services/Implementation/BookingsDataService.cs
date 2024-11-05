using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OlympOnlineStore.API.Data;
using OlympOnlineStore.API.Data.Entities;
using OlympOnlineStore.API.Services.Interfaces;

namespace OlympOnlineStore.API.Services.Implementation;

public class BookingsDataService(OlympOnlineStoreDbContext dbContext) : IBookingsDataService
{
    public async Task<BookingEntity?> Get(Guid bookingId)
    {
        return await dbContext.Bookings.FindAsync(bookingId);
    }

    public async Task<List<BookingEntity>?> GetAll(Expression<Func<BookingEntity, bool>>? predicate = null)
    {
        return await dbContext.Bookings.Where(predicate ?? (_ => true))
            .Include(b => b.PaymentEntities)
            .ToListAsync();
    }

    public async Task<bool> InsertOrUpdate(BookingEntity booking)
    {
        var existedBooking = await dbContext.Bookings.FindAsync(booking.BookingId);
        if (existedBooking is null)
            dbContext.Entry(booking).State = EntityState.Added;
        else
            dbContext.Entry(existedBooking).CurrentValues.SetValues(booking);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Guid bookingId)
    {
        var existedBooking = await dbContext.Bookings.FindAsync(bookingId);
        if (existedBooking is null) return true;
        dbContext.Bookings.Remove(existedBooking);
        return await dbContext.SaveChangesAsync() > 0;
    }
}