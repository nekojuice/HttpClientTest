using HttpClientTest.Domain.Entity;
using HttpClientTest.Services.Interfaces;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;

namespace HttpClientTest.Services.Implements;

public class CWAWeatherService_byClass : ICWAWeatherService_byClass
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private string? _auth;
    public CWAWeatherService_byClass(HttpClient httpClient, IConfiguration configuration) 
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _auth = _configuration.GetValue("WCAWeatherApi:Auth", "");

        _httpClient.BaseAddress = new Uri("https://opendata.cwa.gov.tw/api/v1/rest/datastore/");
        _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    }

    public async Task<CWAWeather.Rootobject?> GetWeatherByClass() 
    {
        var httpResponseMessage = await _httpClient.GetAsync($"F-D0047-061?Authorization={_auth}&limit=10");

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            using (var content = await httpResponseMessage.Content.ReadAsStreamAsync())
            {
                var result = await JsonSerializer.DeserializeAsync<CWAWeather.Rootobject>(content);
                return result;
            }
        }
        return null;
    }
}
