#nullable disable
using OlympOnlineStore.Models.Enums;

namespace OlympOnlineStore.API.Data.Entities;

public class CarEntity
{
    public Guid CarId { get; set; } = Guid.NewGuid();
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public TransmissionType Transmission { get; set; }
    public decimal? PricePerDay { get; set; }
    public decimal? PricePerWeek { get; set; }
    public decimal? PricePerMonth { get; set; }
    public bool Availability { get; set; }
    public string Description { get; set; }
        
    public virtual ICollection<BookingEntity> BookingEntities { get; set; }
    public virtual ICollection<CarImageEntity> ImageEntities { get; set; }
}
