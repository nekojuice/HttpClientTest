using HttpClientTest.Domain.Entity;
using HttpClientTest.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientTest.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CWAWeatherController : ControllerBase
{
    private readonly ICWAWeatherService_byName _weatherServiceName;
    private readonly ICWAWeatherService_byClass _weatherServiceClass;
    private readonly ICWAWeatherService_byRefit _weatherServiceRefit;

    public CWAWeatherController(ICWAWeatherService_byName weatherServiceName, ICWAWeatherService_byClass weatherServiceClass, ICWAWeatherService_byRefit weatherServiceRefit)
    {
        _weatherServiceName = weatherServiceName;
        _weatherServiceClass = weatherServiceClass;
        _weatherServiceRefit = weatherServiceRefit;
    }

    // 具名用戶端
    [HttpGet]
    public async Task<IResult> GetTaipeiWeather_byName_Newtonsoft()
    {
        var result = await _weatherServiceName.GetWeatherByName_Newtonsoft();
        return Results.Ok(result);
    }
    [HttpGet]
    public async Task<IResult> GetTaipeiWeather_byName()
    {
        var result = await _weatherServiceName.GetWeatherByName();
        return Results.Ok(result);
    }

    // 具型別用戶端
    [HttpGet]
    public async Task<IResult> GetTaipeiWeather_byClass()
    {
        var result = await _weatherServiceClass.GetWeatherByClass();
        return Results.Ok(result);
    }

    // 動態生成的用戶端 (Refit)
    [HttpGet]
    public async Task<IResult> GetTaipeiWeather_byRefit()
    {
        var result = await _weatherServiceRefit.GetTaipeiWeather_byRefit();
        return Results.Ok(result);
    }
}
