using OlympOnlineStore.Models.Enums;

namespace OlympOnlineStore.Models.Models;

public class BookingModel
{
    public Guid BookingId { get; set; }
    public Guid UserId { get; set; }
    public Guid CardId { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public BookingStatusType BookingStatus { get; set; }
    public DateTime CreatedAt { get; set; }
}