using HttpClientTest.Services.Interfaces;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using Refit;
using System.Text.Json;

namespace HttpClientTest.Infrastructures.HttpClient;

public static class CWAWeatherHttpClient
{
    private const string _baseUri = "https://opendata.cwa.gov.tw/api/v1/rest/datastore/";
    public static void CWAWeatherHttpClientConfig(this IServiceCollection services)
    {
        // 具名用戶端
        services.AddHttpClient("CWA_Taipei_byName", httpClient =>
        {
            httpClient.BaseAddress = new Uri(_baseUri);
            httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        });

        // 動態生成的用戶端 (Refit)
        services.AddRefitClient<ICWAWeatherService_byRefit>()
            .ConfigureHttpClient(httpClient =>
            {
                httpClient.BaseAddress = new Uri(_baseUri);
                httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });
    }
}
