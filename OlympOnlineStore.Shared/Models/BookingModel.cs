using OlympOnlineStore.Models.Enums;

namespace OlympOnlineStore.Models.Models
{
    public class BookingModel
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int CardId { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public BookingStatusType BookingStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
