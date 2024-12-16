using OlympRentalSystem.Shared.Models;
using Refit;

namespace OlympRentalSystem.UI.HttpClients;

public interface ICarsHttpClient
{
    [Get("/Car/Get")]
    Task<CarDto?> Get([Query] Guid carId);
    
    [Post("/Car/GetByFilter")]
    Task<List<CarDto>?> GetByFilter([Body] FilterModel filter);
    
    [Post("/Car/GetCountByFilter")]
    Task<int> GetCountByFilter([Body] FilterModel filter);
    
    [Post("/Car/InsertOrUpdate")]
    Task<bool> InsertOrUpdate([Body] CarDto car);
}