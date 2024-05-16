using KtWeather.Frontend.Clients;
using KtWeather.Frontend.Components;
using KtWeather.Frontend.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

var ForecastApiBaseUrl = builder.Configuration["ForecastApiBaseUrl"] ??
    throw new Exception("ForecastApiBaseUrl is not set");

var SelectedService = builder.Configuration["SelectedService"] ?? throw new Exception("No SelectedService found.");

switch (SelectedService) {
    case "GeocodeService":
        builder.Services.AddScoped<IGeolocationClient, GeocodeClient>();
        break;
    case "NinjaService":
        builder.Services.AddScoped<IGeolocationClient, NinjaClient>();
        break;
    case "GeoapifyService":
        builder.Services.AddScoped<IGeolocationClient, GeoapifyClient>();
        break;
    case "TestService":
        builder.Services.AddScoped<IGeolocationClient, TestClient>();
        break;
    default:
        throw new Exception("No service found.");
}

builder.Services.AddHttpClient<ForecastClient>(
    client => client.BaseAddress = new Uri(ForecastApiBaseUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
