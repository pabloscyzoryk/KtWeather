namespace KtWeather.Frontend.Models;

using Newtonsoft.Json;

public class NinjaDetails
{
    [JsonProperty("name")]
    public string? name { get; set; }

    [JsonProperty("latitude")]
    public double? latitude { get; set; }

    [JsonProperty("longitude")]
    public double? longitude { get; set; }

    [JsonProperty("country")]
    public string? country { get; set; }
    [JsonProperty("state")]
    public string? state { get; set; }
}


