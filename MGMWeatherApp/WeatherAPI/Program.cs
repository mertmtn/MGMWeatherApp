using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.Concrete.EntityFramework;
using Microsoft.Extensions.Configuration;
using WeatherAPI.Business;
using WeatherAPI.HttpClients;
using WeatherAPI.Models.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ICityDistrictMeasuringService, CityDistrictMeasuringManager>();
builder.Services.AddTransient<ICityDistrictMeasuringDal, EfCityDistrictMeasuringDal>();
builder.Services.AddTransient<ICoordinateService, CoordinateManager>();
builder.Services.AddTransient<ICoordinateDal, EfCoordinateDal>();
builder.Services.Configure<OpenWeatherMapApiInfo>(builder.Configuration.GetSection("OpenWeatherMapApiInfo"));
builder.Services.AddHttpClient<WeatherHttpClient>();
builder.Services.AddTransient<IWeatherService, WeatherBusiness>();

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
