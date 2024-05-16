using KtWeather.Frontend.Models;

namespace KtWeather.Frontend.Interfaces;

public interface IGeolocationClient
{
    public Task<GeolocationResults> GetCoords(string Search);
}
