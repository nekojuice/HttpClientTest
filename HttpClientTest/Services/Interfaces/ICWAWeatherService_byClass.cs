using HttpClientTest.Domain.Entity;

namespace HttpClientTest.Services.Interfaces;

public interface ICWAWeatherService_byClass
{
    public Task<CWAWeather.Rootobject?> GetWeatherByClass();
}
