using KtWeather.Frontend.Interfaces;
using KtWeather.Frontend.Models;

namespace KtWeather.Frontend.Clients;

public class NinjaClient(HttpClient httpClient, IConfiguration configuration) : IGeolocationClient
{
    public readonly IConfiguration _configuration = configuration;
    public async Task<GeolocationResults> GetCoords(string Search)
    {
        string BaseUrl = _configuration["NinjaService:BaseUrl"] ?? throw new Exception("No BaseUrl found for Ninja.");
        string ApiKey = _configuration["NinjaService:ApiKey"] ?? throw new Exception("No ApiKey found for Ninja.");
        string UrlBlueprint = "{0}/geocoding?city={1}";

        httpClient.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);

        List<NinjaDetails>? details = await httpClient.GetFromJsonAsync<List<NinjaDetails>>(string.Format(UrlBlueprint, BaseUrl, Search));

        if (details is null || details[0] is null)
        {
            throw new Exception("No results found");
        }

        string? lon = details[0].longitude?.ToString().Replace(',', '.');
        string? lat = details[0].latitude?.ToString().Replace(',', '.');
        string? displayName = details[0].name;

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