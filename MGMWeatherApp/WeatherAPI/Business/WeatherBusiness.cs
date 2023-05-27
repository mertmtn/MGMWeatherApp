using Business.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Options;
using System.Text.Json;
using WeatherAPI.HttpClients;
using WeatherAPI.Models.Options;
using WeatherAPI.Models.Request;

namespace WeatherAPI.Business
{
    public class WeatherBusiness : IWeatherService
    {
        private ICityDistrictMeasuringService _cityDistrictMeasuringService { get; }
        private ICoordinateService _coordinateService { get; }
        private WeatherHttpClient _weatherHttpClient { get; }
        private OpenWeatherMapApiInfo _apiInfo { get; }
        public WeatherBusiness(WeatherHttpClient weatherHttpClient, IOptions<OpenWeatherMapApiInfo> apiInfoOption, ICityDistrictMeasuringService cityDistrictMeasuringService, ICoordinateService coordinateService)
        {
            _weatherHttpClient = weatherHttpClient;
            _apiInfo = apiInfoOption.Value;
            _coordinateService = coordinateService;
            _cityDistrictMeasuringService = cityDistrictMeasuringService;
        } 


        public async Task<Root> GetAllCountry(WeatherRequest request)
        {
            var requestLink = _apiInfo.OpenWeatherMapApiLink.OneCall;
            requestLink = requestLink.Replace("[Lattitude]", request.Lattitude.ToString());
            requestLink = requestLink.Replace("[Longtitude]", request.Longtitude.ToString());
            requestLink = requestLink.Replace("[ApiKey]", _apiInfo.ApiKey);

            var responseString = await _weatherHttpClient.GetAsync(requestLink);

            var list = JsonSerializer.Deserialize<Root>(responseString);
            return list;
        }


        public async Task<Root> AddMeasuresByPlace(int placeId)
        {
            var coordinates = _coordinateService.GetCoordinateByPlaceId(placeId);
             

            var requestLink = _apiInfo.OpenWeatherMapApiLink.OneCall;
            requestLink = requestLink.Replace("[Lattitude]", coordinates.Data.Latitude.ToString());
            requestLink = requestLink.Replace("[Longtitude]", coordinates.Data.Longitude.ToString());
            requestLink = requestLink.Replace("[ApiKey]", _apiInfo.ApiKey);

            var responseString = await _weatherHttpClient.GetAsync(requestLink);

            var list = JsonSerializer.Deserialize<Root>(responseString);

            foreach (var item in list.daily)
            {
                var code = Convert.ToInt32(item.weather[0].id);
                var weatherTypeId = 1;
                weatherTypeId = GetWeatherTypeId(code, weatherTypeId);
                _cityDistrictMeasuringService.AddMeasureByPlace(
                    new CityDistrictMeasuring
                    {
                        PlaceId=placeId,
                        Humidity = item.humidity,
                        MeasureDate = DateOnly.FromDateTime(item.Date),
                        Pressure = item.pressure,
                        FeelsTemperature = item.feels_like.day - 273,
                        WindSpeed = item.wind_speed,
                        Temperature = item.temp.day - 273,
                        WeatherTypeId = weatherTypeId
                    });
            } 

            return list;
        }

        private static int GetWeatherTypeId(int code, int weatherTypeId)
        {
            switch (code)
            {
                case 801:
                    weatherTypeId = 3;
                    break;
                case 803:
                    weatherTypeId = 3;
                    break;
                case 800:
                    weatherTypeId = 1; break;
                case 804:
                    weatherTypeId = 4; break;
                case 500:
                    weatherTypeId = 8; break;
                case 504:
                case 503:
                case 502:
                    weatherTypeId = 10; break;
                case 600:
                    weatherTypeId = 13; break;
                case 701:
                    weatherTypeId = 6; break;
                case 711:
                case 721:
                    weatherTypeId = 7; break;
                case 231:
                    weatherTypeId = 17; break;
                default:
                    break;
            }

            return weatherTypeId;
        }
    }


    public class Current
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        public DateTime Date => UnixTimeStampToDateTime(this.dt);
        public int dt { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public double dew_point { get; set; }
        public int uvi { get; set; }
        public int clouds { get; set; }
        public int visibility { get; set; }
        public double wind_speed { get; set; }
        public int wind_deg { get; set; }
        public List<Weather> weather { get; set; }
    }

    public class Daily
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        public DateTime Date => UnixTimeStampToDateTime(this.dt);
        public int dt { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public int moonrise { get; set; }
        public int moonset { get; set; }
        public double moon_phase { get; set; }
        public Temp temp { get; set; }
        public FeelsLike feels_like { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public double dew_point { get; set; }
        public double wind_speed { get; set; }
        public int wind_deg { get; set; }
        public double wind_gust { get; set; }
        public List<Weather> weather { get; set; }
        public int clouds { get; set; }
        public double pop { get; set; }
        public double rain { get; set; }
        public double uvi { get; set; }
    }

    public class FeelsLike
    {
        public double day { get; set; }
        public double night { get; set; }
        public double eve { get; set; }
        public double morn { get; set; }
    }

    public class Root
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public string timezone { get; set; }
        public int timezone_offset { get; set; }
        public Current current { get; set; }

        public List<Daily> daily { get; set; }
    }

    public class Temp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
        public double eve { get; set; }
        public double morn { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

}
