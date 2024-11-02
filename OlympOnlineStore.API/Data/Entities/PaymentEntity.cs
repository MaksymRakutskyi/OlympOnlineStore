#nullable disable
using OlympOnlineStore.Models.Enums;

namespace OlympOnlineStore.API.Data.Entities;

public class PaymentEntity
{
    public Guid PaymentId { get; set; }
    public Guid BookingId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethodType PaymentMethod { get; set; }
    public PaymentStatusType PaymentStatus { get; set; }
    public DateTime PaymentDate { get; set; }
    
    public virtual BookingEntity BookingEntity { get; set; }
}
