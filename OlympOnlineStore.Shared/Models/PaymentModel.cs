using OlympOnlineStore.Models.Enums;

namespace OlympOnlineStore.Models.Models;

public class PaymentModel
{
    public Guid PaymentId { get; set; }
    public Guid BookingId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethodType PaymentMethod { get; set; }
    public PaymentStatusType PaymentStatus { get; set; }
    public DateTime PaymentDate { get; set; }
}