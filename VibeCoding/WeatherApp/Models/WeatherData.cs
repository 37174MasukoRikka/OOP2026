namespace WeatherApp.Models {
    public class DailyForecast {
        public string Date { get; set; } = "";

        public double MaxTemperature { get; set; }

        public double MinTemperature { get; set; }

        public int PrecipitationProbability { get; set; }

        public int WeatherCode { get; set; }
    }

    public class WeatherData {
        public double Temperature { get; set; }

        public int Humidity { get; set; }

        public double WindSpeed { get; set; }

        public int WeatherCode { get; set; }

        public List<DailyForecast> DailyForecasts { get; set; }
            = new();
    }
}