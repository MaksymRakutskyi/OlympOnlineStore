using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using OlympRentalSystem.Shared.Models;
using OlympRentalSystem.UI.HttpClients;
using OlympRentalSystem.UI.Models;
using OlympRentalSystem.UI.Resources;

namespace OlympRentalSystem.UI.Components.Pages;

public partial class CarEdit : ComponentBase
{
    [Parameter] public Guid? CarId { get; set; }
    [Inject] protected IStringLocalizer<SharedResources> Localizer { get; set; } = null!;
    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;
    [Inject] protected IMapper Mapper { get; set; } = null!;
    [Inject] protected ICarsHttpClient CarsHttpClient { get; set; } = null!;
    [Inject] protected ISnackbar Snackbar { get; set; } = null!;
    
    private MudForm? Form { get; set; }
    protected Car Car { get; set; } = new();
    protected bool IsValid { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (CarId.HasValue && CarId.Value != Guid.Empty)
        {
            var carDto = await CarsHttpClient.Get(CarId.Value);
            if (carDto != null) Car = Mapper.Map<Car>(carDto);
        }
    }

    private async Task SaveAction()
    {
        try
        {
            if (Form is null || !Form.IsValid) return;
        
            var carDto = Mapper.Map<CarDto>(Car);
            var result = await CarsHttpClient.InsertOrUpdate(carDto);

            if (result)
            {
                Snackbar.Add(Localizer[CarId is null ? "CarCreated" : "CarUpdated"], Severity.Success);   
                NavigationManager.NavigateTo("cars");
                return;
            }
        
            Snackbar.Add(Localizer["SaveError"], Severity.Error);
        }
        catch (Exception e)
        {
            Snackbar.Add(Localizer["SaveError"], Severity.Error);
            Snackbar.Add(e.Message);
        }
    }

    private void CancelAction()
    {
        NavigationManager.NavigateTo("cars");
    }
}