#nullable disable
using OlympOnlineStore.Models.Enums;

namespace OlympOnlineStore.Models.Models;

public class CarModel
{
    public Guid CarId { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public TransmissionType Transmission { get; set; }
    public decimal PricePerDay { get; set; }
    public decimal PricePerWeek { get; set; }
    public decimal PricePerMonth { get; set; }
    public bool Availability { get; set; }
    public string ImageBase64 { get; set; }
    public string Description { get; set; }
}