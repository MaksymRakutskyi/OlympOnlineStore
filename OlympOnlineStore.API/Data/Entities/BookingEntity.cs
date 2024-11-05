#nullable disable
using OlympOnlineStore.Models.Enums;

namespace OlympOnlineStore.API.Data.Entities;

public class BookingEntity
{
    public Guid BookingId { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid CarId { get; set; }
    public DateTime StarDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public BookingStatusType BookingStatus { get; set; }
    public DateTime CreatedAt { get; set; }
        
    public virtual UserEntity UserEntity { get; set; }
    public virtual CarEntity CarEntity { get; set; }
    public virtual ICollection<PaymentEntity> PaymentEntities { get; set; }
}
