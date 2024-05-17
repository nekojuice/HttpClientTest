using HttpClientTest.Domain.Entity;
using HttpClientTest.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using static HttpClientTest.Domain.Entity.CWAWeather;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HttpClientTest.Services.Implements;

public class CWAWeatherService_byName : ICWAWeatherService_byName
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private string? _auth;

    public CWAWeatherService_byName(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _auth = _configuration.GetValue("WCAWeatherApi:Auth", "");
    }

    // System.Text.Json.JsonSerializer
    public async Task<CWAWeather.Rootobject?> GetWeatherByName()
    {
        var httpClient = _httpClientFactory.CreateClient("CWA_Taipei_byName");
        var httpResponseMessage = await httpClient.GetAsync($"F-D0047-061?Authorization={_auth}&limit=10");
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

    // Newtonsoft.Json.JsonConvert
    public async Task<CWAWeather.Rootobject?> GetWeatherByName_Newtonsoft(string? text)
    {
        string qry = null;
        if (string.IsNullOrEmpty(text))
        {

        }
        var httpClient = _httpClientFactory.CreateClient("CWA_Taipei_byName");


        var httpResponseMessage = await httpClient.GetAsync($"F-D0047-061?Authorization={_auth}&limit=10");
        
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            string content = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CWAWeather.Rootobject>(content);
            return result;
        }
        return null;
    }
}
