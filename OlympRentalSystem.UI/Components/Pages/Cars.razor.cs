using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using OlympRentalSystem.Shared.Models;
using OlympRentalSystem.UI.HttpClients;
using OlympRentalSystem.UI.Models;
using OlympRentalSystem.UI.Resources;

namespace OlympRentalSystem.UI.Components.Pages;

public partial class Cars : ComponentBase
{
    [Inject] protected IStringLocalizer<SharedResources> Localizer { get; set; } = null!;
    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;
    [Inject] protected ICarsHttpClient CarsHttpClient { get; set; } = null!;
    [Inject] protected IMapper Mapper { get; set; } = null!;
    [Inject] protected ISnackbar Snackbar { get; set; } = null!;

    private MudTable<Car> CarTable { get; set; } = null!;

    private string? _searchTerm;
    
    private void OnSearch(string searchTerm)
    {
        _searchTerm = searchTerm;
        CarTable.ReloadServerData();
    }
    
    private async Task<TableData<Car>> LoadServerData(TableState state, CancellationToken cancellationToken)
    {
        try
        {
            //var sample = GetSampleCars();
            //return new TableData<Car> { Items = sample, TotalItems = sample.Count };
            var filter = Mapper.Map<FilterModel>(state);
            filter.SearchTerm = _searchTerm ?? string.Empty;
            var carsDto = await CarsHttpClient.GetByFilter(filter);
            var items = Mapper.Map<List<Car>>(carsDto);
            var count = await CarsHttpClient.GetCountByFilter(filter);
            return new TableData<Car> { Items = items, TotalItems = count };
        }
        catch (Exception e)
        {
            Snackbar.Add(Localizer["FailedToLoadData"], Severity.Error);
            Snackbar.Add(e.Message, Severity.Error);
            return new TableData<Car>();
        }
    }

    private void OnRowClick(TableRowClickEventArgs<Car> args)
    {
        var carId = args.Item?.CarId;
        if (carId != null)
            NavigationManager.NavigateTo($"car/edit/{carId}");
    }

    private void OnAddClick()
    {
        NavigationManager.NavigateTo("car/edit/");
    }

    private void OnDeleteClick(Guid carId)
    {
        
    }

    public static List<Car> GetSampleCars()
    {
        return new List<Car>
        {
            new Car
            {
                CarId = Guid.NewGuid(),
                Brand = "Tesla",
                Model = "Model S",
                Description = "Електричний люксовий седан із передовими функціями.",
                PricePerDay = 99.99m,
                PricePerWeek = 599.99m,
                PricePerMonth = 1999.99m,
                Availability = true,
                Images = new List<string>()
            },
            new Car
            {
                CarId = Guid.NewGuid(),
                Brand = "Toyota",
                Model = "Corolla",
                Description = "Надійний та економний компактний седан.",
                PricePerDay = 29.99m,
                PricePerWeek = 179.99m,
                PricePerMonth = 599.99m,
                Availability = true,
                Images = new List<string>()
            },
            new Car
            {
                CarId = Guid.NewGuid(),
                Brand = "BMW",
                Model = "X5",
                Description = "Просторий та розкішний позашляховик для сімейних подорожей.",
                PricePerDay = 149.99m,
                PricePerWeek = 899.99m,
                PricePerMonth = 2999.99m,
                Availability = false,
                Images = new List<string>()
            },
            new Car
            {
                CarId = Guid.NewGuid(),
                Brand = "Ford",
                Model = "Mustang",
                Description = "Класичний американський маслкар із потужною продуктивністю.",
                PricePerDay = 199.99m,
                PricePerWeek = 1199.99m,
                PricePerMonth = 3999.99m,
                Availability = true,
                Images = new List<string>()
            },
            new Car
            {
                CarId = Guid.NewGuid(),
                Brand = "Honda",
                Model = "Civic",
                Description = "Стильний та практичний седан із чудовими характеристиками.",
                PricePerDay = 39.99m,
                PricePerWeek = 239.99m,
                PricePerMonth = 799.99m,
                Availability = true,
                Images = new List<string>()
            }
        };
    }
}