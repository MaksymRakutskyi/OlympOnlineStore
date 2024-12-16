using OlympRentalSystem.Shared.Enums;

namespace OlympRentalSystem.Shared.Models;

public class BookingDto
{
    public Guid BookingId { get; set; }
    public Guid CarId { get; set; }
    public string? CustomerName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public BookingStatusType BookingStatus { get; set; }
}