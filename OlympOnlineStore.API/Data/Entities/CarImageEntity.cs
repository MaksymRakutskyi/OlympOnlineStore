#nullable disable
namespace OlympOnlineStore.API.Data.Entities;

public class CarImageEntity
{
    public Guid ImageId { get; set; } = Guid.NewGuid();
    public Guid CarId { get; set; }
    public string ImageBase64 { get; set; }
    public int Order { get; set; }
    
    public virtual CarEntity CarEntity { get; set; }
}