namespace OlympRentalSystem.UI.Models;

public class Car
{
    public Guid CarId { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? Description { get; set; }
    public decimal? PricePerDay { get; set; }
    public decimal? PricePerWeek { get; set; }
    public decimal? PricePerMonth { get; set; }
    public bool Availability { get; set; }
    public List<string>? Images { get; set; }
}