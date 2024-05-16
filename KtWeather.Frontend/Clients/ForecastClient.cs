using KtWeather.Frontend.Models;

namespace KtWeather.Frontend.Clients;

public class ForecastClient(HttpClient httpClient)
{
    public async Task<WeatherDetails?>GetWeatherDataAsync(string latitude, string longitude, string startDate, string endDate)
    {
        string urlRest = "https://archive-api.open-meteo.com/v1/archive?latitude={0}&longitude={1}&start_date={2}&end_date={3}&daily=temperature_2m_mean";
        return await httpClient.GetFromJsonAsync<WeatherDetails>(string.Format(urlRest, latitude, longitude, startDate, endDate));
    }
}
