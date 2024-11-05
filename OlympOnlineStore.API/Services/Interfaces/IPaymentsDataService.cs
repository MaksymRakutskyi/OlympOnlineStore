using System.Linq.Expressions;
using OlympOnlineStore.API.Data.Entities;

namespace OlympOnlineStore.API.Services.Interfaces;

public interface IPaymentsDataService
{
    Task<PaymentEntity?> Get(Guid paymentId);
    Task<List<PaymentEntity>?> GetAll(Expression<Func<PaymentEntity, bool>>? predicate = null);
    Task<bool> InsertOrUpdate(PaymentEntity payment);
    Task<bool> Delete(Guid paymentId);
}