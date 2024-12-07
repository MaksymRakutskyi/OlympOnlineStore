using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OlympOnlineStore.UI.Resources;

namespace OlympOnlineStore.UI.Components.Pages;

public partial class Catalog : ComponentBase
{
    [Inject] protected IStringLocalizer<SharedResources> Localizer { get; set; } = null!;
}