using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OlympOnlineStore.API.Data;
using OlympOnlineStore.API.Data.Entities;
using OlympOnlineStore.API.Services.Interfaces;

namespace OlympOnlineStore.API.Services.Implementation;

public class PaymentsDataService(OlympOnlineStoreDbContext dbContext) : IPaymentsDataService
{
    public async Task<PaymentEntity?> Get(Guid paymentId)
    {
        return await dbContext.Payments.FindAsync(paymentId);
    }

    public async Task<List<PaymentEntity>?> GetAll(Expression<Func<PaymentEntity, bool>>? predicate = null)
    {
        return await dbContext.Payments.Where(predicate ?? (_ => true)).ToListAsync();
    }

    public async Task<bool> InsertOrUpdate(PaymentEntity payment)
    {
        var existedPayment = await dbContext.Payments.FindAsync(payment.PaymentId);
        if (existedPayment is null)
            dbContext.Entry(payment).State = EntityState.Added;
        else
            dbContext.Entry(existedPayment).CurrentValues.SetValues(payment);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Guid paymentId)
    {
        var existedPayment = await dbContext.Payments.FindAsync(paymentId);
        if (existedPayment is null) return true;
        dbContext.Payments.Remove(existedPayment);
        return await dbContext.SaveChangesAsync() > 0;
    }
}