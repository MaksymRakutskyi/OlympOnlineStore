using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OlympRentalSystem.UI.Resources;

namespace OlympRentalSystem.UI.Components.Pages;

public partial class Catalog : ComponentBase
{
    [Inject] protected IStringLocalizer<SharedResources> Localizer { get; set; } = null!;
}