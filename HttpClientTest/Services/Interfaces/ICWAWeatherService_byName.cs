using HttpClientTest.Domain.Entity;

namespace HttpClientTest.Services.Interfaces;

public interface ICWAWeatherService_byName
{
    public Task<CWAWeather.Rootobject?> GetWeatherByName();
    public Task<CWAWeather.Rootobject?> GetWeatherByName_Newtonsoft();
}
