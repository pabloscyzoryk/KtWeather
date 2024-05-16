using KtWeather.Frontend.Interfaces;
using KtWeather.Frontend.Models;

namespace KtWeather.Frontend.Clients;

public class GeocodeClient(HttpClient httpClient, IConfiguration configuration) : IGeolocationClient
{
    public readonly IConfiguration _configuration = configuration;
    public async Task<GeolocationResults> GetCoords(string Search)
    {
        string BaseUrl = _configuration["GeocodeService:BaseUrl"] ?? throw new Exception("No BaseUrl found for Geocode.");
        string ApiKey = _configuration["GeocodeService:ApiKey"] ?? throw new Exception("No ApiKey found for Geocode.");
        string UrlBlueprint = "{0}/search?q={1}&api_key={2}";
        List<GeocodeDetails>? details = await httpClient.GetFromJsonAsync<List<GeocodeDetails>>(string.Format(UrlBlueprint, BaseUrl, Search, ApiKey));

        if (details is null || details[0] is null)
        {
            throw new Exception("No results found");
        }

        string? lon = details[0].lon;
        string? lat = details[0].lat;
        string? displayName = details[0].display_name;

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
