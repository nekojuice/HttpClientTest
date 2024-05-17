using HttpClientTest.Infrastructures.HttpClient;
using HttpClientTest.Services.Implements;
using HttpClientTest.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpClient
builder.Services.AddHttpClient();
// CWA weather
builder.Services.CWAWeatherHttpClientConfig();
builder.Services.AddHttpClient<ICWAWeatherService_byClass, CWAWeatherService_byClass>();


//Service
builder.Services.AddScoped<ICWAWeatherService_byName, CWAWeatherService_byName>();
builder.Services.AddScoped<ICatPostTestService, CatPostTestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
