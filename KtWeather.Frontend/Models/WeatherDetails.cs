namespace KtWeather.Frontend.Models;

using Newtonsoft.Json;
using System.Collections.Generic;

public class Daily
{
    [JsonProperty("time")]
    public List<string>? time { get; set; }

    [JsonProperty("temperature_2m_mean")]
    public List<double>? temperature_2m_mean { get; set; }
}

public class DailyUnits
{
    [JsonProperty("time")]
    public string? time { get; set; }

    [JsonProperty("temperature_2m_mean")]
    public string? temperature_2m_mean { get; set; }
}

public class WeatherDetails
{
    [JsonProperty("latitude")]
    public double? latitude { get; set; }

    [JsonProperty("longitude")]
    public double? longitude { get; set; }

    [JsonProperty("generationtime_ms")]
    public double? generationtime_ms { get; set; }

    [JsonProperty("utc_offset_seconds")]
    public int? utc_offset_seconds { get; set; }

    [JsonProperty("timezone")]
    public string? timezone { get; set; }

    [JsonProperty("timezone_abbreviation")]
    public string? timezone_abbreviation { get; set; }

    [JsonProperty("elevation")]
    public double? elevation { get; set; }

    [JsonProperty("daily_units")]
    public DailyUnits? daily_units { get; set; }

    [JsonProperty("daily")]
    public Daily? daily { get; set; }
}