using HttpClientTest.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace HttpClientTest.Services.Interfaces
{
    public interface ICWAWeatherService_byRefit
    {
        [Get($"/F-D0047-061?Authorization=CWA-F74F8BDA-F942-4CA0-8A62-37BAE5B5B90D&limit=10")]
        public Task<CWAWeather.Rootobject?> GetTaipeiWeather_byRefit();
    }
}
