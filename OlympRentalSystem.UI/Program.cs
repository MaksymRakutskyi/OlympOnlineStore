using Blazored.LocalStorage;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;
using OlympRentalSystem.UI.Components;
using OlympRentalSystem.UI.HttpClients;
using OlympRentalSystem.UI.Profiles;
using Refit;

var builder = WebApplication.CreateBuilder(args);

var defaultCulture = builder.Configuration.GetValue<string>("DefaultCulture") ?? "uk-UA";
var supportedCultures = builder.Configuration.GetSection("SupportedCultures").Get<string[]>() ?? [defaultCulture];

builder.Services.AddLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.AddSupportedCultures(supportedCultures);
    options.AddSupportedUICultures(supportedCultures);
    options.SetDefaultCulture(defaultCulture);
    options.ApplyCurrentCultureToResponseHeaders = false;
});

builder.Services.AddControllers();
builder.Services.AddMudServices();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAutoMapper(typeof(OlympRentalSystemProfile));

var apiUrl = builder.Configuration.GetValue<string>("ApiUrl") ?? "http://localhost:5265";

//builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
builder.Services.AddRefitClient<ICarsHttpClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiUrl));


builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var app = builder.Build();

app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.MapControllers();



app.Run();