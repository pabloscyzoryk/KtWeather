namespace KtWeather.Frontend.Models;

using System.Collections.Generic;
using Newtonsoft.Json;

public class GeocodeDetails
{
    [JsonProperty("place_id")]
    public int? place_id { get; set; }

    [JsonProperty("licence")]
    public string? licence { get; set; }

    [JsonProperty("osm_type")]
    public string? osm_type { get; set; }

    [JsonProperty("osm_id")]
    public object? osm_id { get; set; }

    [JsonProperty("boundingbox")]
    public List<string>? boundingbox { get; set; }

    [JsonProperty("lat")]
    public string? lat { get; set; }

    [JsonProperty("lon")]
    public string? lon { get; set; }

    [JsonProperty("display_name")]
    public string? display_name { get; set; }

    [JsonProperty("class")]
    public string? @class { get; set; }

    [JsonProperty("type")]
    public string? type { get; set; }

    [JsonProperty("importance")]
    public double? importance { get; set; }
}

