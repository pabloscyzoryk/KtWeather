namespace KtWeather.Frontend.Models;

using System.Collections.Generic;
using Newtonsoft.Json;

      public class Bbox
    {
        [JsonProperty("lon1")]
        public double? lon1 { get; set; }

        [JsonProperty("lat1")]
        public double? lat1 { get; set; }

        [JsonProperty("lon2")]
        public double? lon2 { get; set; }

        [JsonProperty("lat2")]
        public double? lat2 { get; set; }
    }

    public class Datasource
    {
        [JsonProperty("sourcename")]
        public string? sourcename { get; set; }

        [JsonProperty("attribution")]
        public string? attribution { get; set; }

        [JsonProperty("license")]
        public string? license { get; set; }

        [JsonProperty("url")]
        public string? url { get; set; }
    }

    public class Parsed
    {
        [JsonProperty("city")]
        public string? city { get; set; }

        [JsonProperty("expected_type")]
        public string? expected_type { get; set; }
    }

    public class Query
    {
        [JsonProperty("text")]
        public string? text { get; set; }

        [JsonProperty("parsed")]
        public Parsed? parsed { get; set; }
    }

    public class Rank
    {
        [JsonProperty("importance")]
        public double? importance { get; set; }

        [JsonProperty("popularity")]
        public double? popularity { get; set; }

        [JsonProperty("confidence")]
        public int? confidence { get; set; }

        [JsonProperty("confidence_city_level")]
        public int? confidence_city_level { get; set; }

        [JsonProperty("match_type")]
        public string? match_type { get; set; }
    }

    public class Result
    {
        [JsonProperty("datasource")]
        public Datasource? datasource { get; set; }

        [JsonProperty("country")]
        public string? country { get; set; }

        [JsonProperty("country_code")]
        public string? country_code { get; set; }

        [JsonProperty("state")]
        public string? state { get; set; }

        [JsonProperty("city")]
        public string? city { get; set; }

        [JsonProperty("lon")]
        public double? lon { get; set; }

        [JsonProperty("lat")]
        public double? lat { get; set; }

        [JsonProperty("result_type")]
        public string? result_type { get; set; }

        [JsonProperty("formatted")]
        public string? formatted { get; set; }

        [JsonProperty("address_line1")]
        public string? address_line1 { get; set; }

        [JsonProperty("address_line2")]
        public string? address_line2 { get; set; }

        [JsonProperty("category")]
        public string? category { get; set; }

        [JsonProperty("timezone")]
        public Timezone? timezone { get; set; }

        [JsonProperty("plus_code")]
        public string? plus_code { get; set; }

        [JsonProperty("plus_code_short")]
        public string? plus_code_short { get; set; }

        [JsonProperty("rank")]
        public Rank? rank { get; set; }

        [JsonProperty("place_id")]
        public string? place_id { get; set; }

        [JsonProperty("bbox")]
        public Bbox? bbox { get; set; }

        [JsonProperty("county")]
        public string? county { get; set; }

        [JsonProperty("postcode")]
        public string? postcode { get; set; }

        [JsonProperty("state_code")]
        public string? state_code { get; set; }
    }

    public class GeoapifyDetails
    {
        [JsonProperty("results")]
        public List<Result>? results { get; set; }

        [JsonProperty("query")]
        public Query? query { get; set; }
    }

    public class Timezone
    {
        [JsonProperty("name")]
        public string? name { get; set; }

        [JsonProperty("offset_STD")]
        public string? offset_STD { get; set; }

        [JsonProperty("offset_STD_seconds")]
        public int? offset_STD_seconds { get; set; }

        [JsonProperty("offset_DST")]
        public string? offset_DST { get; set; }

        [JsonProperty("offset_DST_seconds")]
        public int? offset_DST_seconds { get; set; }

        [JsonProperty("abbreviation_STD")]
        public string? abbreviation_STD { get; set; }

        [JsonProperty("abbreviation_DST")]
        public string? abbreviation_DST { get; set; }
    }

