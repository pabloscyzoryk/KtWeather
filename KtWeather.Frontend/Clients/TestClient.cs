using KtWeather.Frontend.Interfaces;
using KtWeather.Frontend.Models;

namespace KtWeather.Frontend.Clients;

public class TestClient(HttpClient httpClient, IConfiguration configuration) : IGeolocationClient
{
    public readonly IConfiguration _configuration = configuration;
    public async Task<GeolocationResults> GetCoords(string Search)
    {
        string Url = _configuration["TestService:JsonFilePath"] ?? throw new Exception("No JsonFilePath found for Test.");
        GeolocationResults? details = await httpClient.GetFromJsonAsync<GeolocationResults>(Url) ?? throw new Exception("No results found");

        string? lon = details.Longitude.Replace(",", ".");
        string? lat = details.Latitude.Replace(",", ".");
        string? displayName = details.DisplayName;

        if (lon is null || lat is null || displayName is null)
        {
            throw new Exception("Could not retrieve results.");
        }

        return new GeolocationResults
        {
            Latitude = lat,
            Longitude = lon,
            DisplayName = displayName
        };

    }
}