using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OlympOnlineStore.API.Data;
using OlympOnlineStore.API.Services.Implementation;
using OlympOnlineStore.API.Services.Interfaces;
using OlympOnlineStore.API.Utils;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Authorization with Bearer scheme (Bearer token)."
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
    //options.CustomSchemaIds(x => x.FullName);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!))
    });

builder.Services.AddDbContext<OlympOnlineStoreDbContext>(optionsBuilder => 
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();
builder.Services.AddTransient<IUsersDataService, UsersDataService>();
builder.Services.AddTransient<ICarsDataService, CarsDataService>();
builder.Services.AddTransient<ICarImagesDataService, CarImagesDataService>();
builder.Services.AddTransient<IBookingsDataService, BookingsDataService>();
builder.Services.AddTransient<IPaymentsDataService, PaymentsDataService>();

// builder.Services.AddHttpClient("Token", httpClient => { httpClient.Timeout = TimeSpan.FromSeconds(60); })
//     .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
//     {
//         ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
//     });

builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OlympOnlineStoreDbContext>();
    dbContext.Database.Migrate();
    dbContext.Database.EnsureCreated();
    DataHelper.SeedDatabase(dbContext);
}

app.UseSwagger();
app.UseSwaggerUI(options => options.DocExpansion(DocExpansion.None));

app.UseRouting();

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
