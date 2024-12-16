using OlympRentalSystem.Shared.Enums;

namespace OlympRentalSystem.Shared.Models;

public class PaymentDto
{
    public Guid PaymentId { get; set; }
    public Guid BookingId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethodType PaymentMethod { get; set; }
    public PaymentStatusType PaymentStatus { get; set; }
    public DateTime PaymentDate { get; set; }
    public BookingDto? Booking { get; set; }
}