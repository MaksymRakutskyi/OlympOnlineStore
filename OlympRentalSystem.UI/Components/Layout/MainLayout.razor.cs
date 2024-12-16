using System.Globalization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MudBlazor;
using OlympRentalSystem.UI.Resources;

namespace OlympRentalSystem.UI.Components.Layout;

public partial class MainLayout
{
    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;
    [Inject] protected IStringLocalizer<SharedResources> Localizer { get; set; } = null!;
    [Inject] protected IOptions<RequestLocalizationOptions> LocalizationOptions { get; set; } = null!;
    [Inject] protected ILocalStorageService LocalStorage { get; set; } = null!;
    [Inject] protected IConfiguration Configuration { get; set; } = null!;
    
    
    protected readonly MudTheme CustomTheme = new MudTheme
    {
        PaletteLight = new PaletteLight
        {
            Primary = "#1E88E5",        // Головний колір (синій для акценту)
            Secondary = "#FFC107",     // Акцентний колір (золото для преміум відчуття)
            Background = "#F5F5F5",    // Фон (м'який світлий сірий)
            Surface = "#FFFFFF",       // Поверхня (білий для чистоти дизайну)
            AppbarBackground = "#1E88E5", // Фон AppBar (головний синій)
            DrawerBackground = "#FFFFFF", // Фон меню (білий)
            DrawerText = "#000000",    // Текст у меню
            TextPrimary = "#212121",   // Основний текст (темно-сірий)
            TextSecondary = "#757575", // Вторинний текст (світло-сірий)
            ActionDefault = "#1E88E5", // Дія (наприклад, кнопки)
            Error = "#D32F2F",         // Колір для помилок (червоний)
            Success = "#388E3C",       // Колір успіху (зелений)
            Warning = "#FFA000",       // Попередження (теплий жовтий)
        },
        PaletteDark = new PaletteDark
        {
            Primary = "#1E88E5",        // Головний колір (той самий синій для акценту)
            Secondary = "#FFC107",     // Акцентний колір (золото, що добре виглядає на темному фоні)
            Background = "#121212",    // Фон (глибокий чорний)
            Surface = "#1E1E1E",       // Поверхня (темно-сірий)
            AppbarBackground = "#1E1E1E", // Фон AppBar (темно-сірий)
            DrawerBackground = "#1E1E1E", // Фон меню (темно-сірий)
            DrawerText = "#FFFFFF",    // Текст у меню
            TextPrimary = "#E0E0E0",   // Основний текст (світло-сірий)
            TextSecondary = "#B0B0B0", // Вторинний текст (трохи темніший сірий)
            ActionDefault = "#1E88E5", // Дія (той самий синій для консистенції)
            Error = "#EF5350",         // Колір для помилок (трохи світліший червоний)
            Success = "#66BB6A",       // Колір успіху (яскравий зелений)
            Warning = "#FFCA28",       // Попередження (теплий жовтий)
        }
    };

    protected bool IsDrawerOpen = false;

    private CultureInfo CurrentCulture { get; set; } = CultureInfo.CurrentUICulture;
    private List<CultureInfo> SupportedCultures { get; set; } = [];


    protected override async Task OnInitializedAsync()
    {
        SupportedCultures.AddRange(LocalizationOptions.Value.SupportedUICultures ?? [CurrentCulture]);
        await base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // var storedCulture = await LocalStorage.GetItemAsync<string>("Culture") ?? _cultures.FirstOrDefault() ?? "uk-UA";
            // if (!string.IsNullOrWhiteSpace(storedCulture))
            //     await ChangeCulture(storedCulture, false);
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    private void DrawerToggle()
    {
        IsDrawerOpen = !IsDrawerOpen;
    }
    
    private void ApplySelectedCulture(string culture)
    {
        if (culture == CultureInfo.CurrentUICulture.Name) 
            return;
        
        var uri = new Uri(NavigationManager.Uri)
            .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
        var cultureEscaped = Uri.EscapeDataString(culture);
        var uriEscaped = Uri.EscapeDataString(uri);

        NavigationManager.NavigateTo(
            $"Culture/Set?culture={cultureEscaped}&redirectUri={uriEscaped}",
            forceLoad: true);
    }
    
    public static string GetFlagEmoji(string countryCode)
    {
        if (string.IsNullOrEmpty(countryCode) || countryCode.Length != 2)
            return string.Empty;

        return char.ConvertFromUtf32(0x1F1E6  + (countryCode[0] - 'A')) +
               char.ConvertFromUtf32(0x1F1E6 + (countryCode[1] - 'A'));
    }
}