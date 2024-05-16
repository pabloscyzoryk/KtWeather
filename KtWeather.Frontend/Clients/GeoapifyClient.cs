using KtWeather.Frontend.Interfaces;
using KtWeather.Frontend.Models;

namespace KtWeather.Frontend.Clients;

public class GeoapifyClient(HttpClient httpClient, IConfiguration configuration) : IGeolocationClient
{

    public readonly IConfiguration _configuration = configuration;
    public async Task<GeolocationResults> GetCoords(string Search)
    {
        string BaseUrl = _configuration["GeoapifyService:BaseUrl"] ?? throw new Exception("No BaseUrl found for Geoapify.");
        string ApiKey = _configuration["GeoapifyService:ApiKey"]?? throw new Exception("No ApiKey found for Geoapify.");
        string UrlBlueprint = "{0}search?text={1}&apiKey={2}&format=json";

        GeoapifyDetails? details = await httpClient.GetFromJsonAsync<GeoapifyDetails>(string.Format(UrlBlueprint, BaseUrl, Search, ApiKey));

        if (details is null || details.results is null || details.results.Count == 0 || details.results[0] is null)
        {
            throw new Exception("No results found");
        }

        Result? result = details.results[0] ?? throw new Exception("Could not retrieve results.");

        string? lon = result.lon?.ToString().Replace(',', '.');
        string? lat = result.lat?.ToString().Replace(',', '.');
        string? displayName = result.formatted;

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
