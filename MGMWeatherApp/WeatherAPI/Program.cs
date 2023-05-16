using Microsoft.Extensions.Configuration;
using WeatherAPI.Business;
using WeatherAPI.HttpClients;
using WeatherAPI.Models.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<OpenWeatherMapApiInfo>(builder.Configuration.GetSection("OpenWeatherMapApiInfo"));
builder.Services.AddHttpClient<WeatherHttpClient>();
builder.Services.AddTransient<IWeatherBusiness, WeatherBusiness>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
