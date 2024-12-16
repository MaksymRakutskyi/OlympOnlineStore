namespace OlympRentalSystem.Shared.Models;

public class FilterModel
{
    public string SearchTerm { get; set; } = string.Empty;
    public string OrderBy { get; set; } = string.Empty;
    public bool IsDescending { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; } = 10;
}