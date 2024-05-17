using HttpClientTest.Domain.Entity;
using HttpClientTest.Services.Interfaces;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace HttpClientTest.Services.Implements
{
    public class CatPostTestService : ICatPostTestService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string? _auth;
        public CatPostTestService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _auth = _configuration.GetValue("CATtestApi:Auth", "");

            _httpClient.BaseAddress = new Uri("https://localhost:7046/api/Login/PostTest");
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        }

        public async Task<LoginDTO?> PostTest(LoginDTO request)
        {
            var dtoJson = new StringContent(JsonSerializer.Serialize(request),
                                        Encoding.UTF8,
                                        Application.Json);
            var httpResponseMessage = await _httpClient.PostAsync($"Login/PostTest", dtoJson);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using (var content = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    var result = await JsonSerializer.DeserializeAsync<LoginDTO>(content);  // 懶ㄉ改回傳格式 同樣東西丟回來而已
                    return result;
                }
            }
            return null;
        }

        public async Task<LoginDTO?> PostTestWithAuth(LoginDTO request)
        {
            var dtoJson = new StringContent(JsonSerializer.Serialize(request),
                                        Encoding.UTF8,
                                        Application.Json);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _auth);
            var httpResponseMessage = await _httpClient.PostAsync($"Login/PostTestWithAuth", dtoJson);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using (var content = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    var result = await JsonSerializer.DeserializeAsync<LoginDTO>(content);  // 懶ㄉ改回傳格式 同樣東西丟回來而已
                    return result;
                }
            }
            return null;
        }
    }
}