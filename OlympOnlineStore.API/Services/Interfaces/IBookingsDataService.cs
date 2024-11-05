using System.Linq.Expressions;
using OlympOnlineStore.API.Data.Entities;

namespace OlympOnlineStore.API.Services.Interfaces;

public interface IBookingsDataService
{
   Task<BookingEntity?> Get(Guid bookingId);
   Task<List<BookingEntity>?> GetAll(Expression<Func<BookingEntity, bool>>? predicate = null);
   Task<bool> InsertOrUpdate(BookingEntity booking);
   Task<bool> Delete(Guid bookingId);
}