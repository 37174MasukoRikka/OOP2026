using System.Net.Http;
using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Services {
    public class WeatherService {
        private readonly HttpClient _httpClient = new();

        public async Task<WeatherData> GetTokyoWeatherAsync() {
            string url =
                "https://api.open-meteo.com/v1/forecast" +
                "?latitude=35.6895" +
                "&longitude=139.6917" +
                "&current=temperature_2m,relative_humidity_2m,wind_speed_10m,weather_code" +
                "&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max" +
                "&forecast_days=7" +
                "&timezone=Asia%2FTokyo";

            string json = await _httpClient.GetStringAsync(url);

            JsonDocument doc = JsonDocument.Parse(json);

            WeatherData data = new();

            var current = doc.RootElement.GetProperty("current");

            data.Temperature =
                current.GetProperty("temperature_2m").GetDouble();

            data.Humidity =
                current.GetProperty("relative_humidity_2m").GetInt32();

            data.WindSpeed =
                current.GetProperty("wind_speed_10m").GetDouble();

            data.WeatherCode =
                current.GetProperty("weather_code").GetInt32();

            var daily =
                doc.RootElement.GetProperty("daily");

            var dates =
                daily.GetProperty("time");

            var maxTemps =
                daily.GetProperty("temperature_2m_max");

            var minTemps =
                daily.GetProperty("temperature_2m_min");

            var rain =
                daily.GetProperty("precipitation_probability_max");

            var weatherCodes =
                daily.GetProperty("weather_code");

            for (int i = 0; i < dates.GetArrayLength(); i++) {
                data.DailyForecasts.Add(new DailyForecast {
                    Date = dates[i].GetString() ?? "",

                    MaxTemperature =
                        maxTemps[i].GetDouble(),

                    MinTemperature =
                        minTemps[i].GetDouble(),

                    PrecipitationProbability =
                        rain[i].GetInt32(),

                    WeatherCode =
                        weatherCodes[i].GetInt32()
                });
            }

            return data;
        }
    }
}