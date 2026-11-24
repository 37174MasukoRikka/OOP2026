using System.Globalization;
using System.Text;
using System.Windows;
using WeatherApp.Services;

namespace WeatherApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(
            object sender,
            RoutedEventArgs e) {
            WeatherService service = new();

            var weather =
                await service.GetTokyoWeatherAsync();

            StringBuilder sb = new();

            sb.AppendLine(
                $"現在気温 : {weather.Temperature} ℃");

            sb.AppendLine(
                $"湿度 : {weather.Humidity} %");

            sb.AppendLine(
                $"風速 : {weather.WindSpeed} m/s");

            sb.AppendLine(
                $"天気 : {GetWeatherText(weather.WeatherCode)}");

            CurrentWeatherText.Text = sb.ToString();

            ForecastList.Items.Clear();

            foreach (var day in weather.DailyForecasts) {
                DateTime date =
                    DateTime.Parse(day.Date);

                string formattedDate =
                    date.ToString("M/d(ddd)", new CultureInfo("ja-JP"));

                ForecastList.Items.Add(
                    $"{formattedDate}  " +
                    $"{GetWeatherText(day.WeatherCode)}  " +
                    $"最高:{day.MaxTemperature}℃  " +
                    $"最低:{day.MinTemperature}℃  " +
                    $"降水確率:{day.PrecipitationProbability}%");
            }
        }

        private string GetWeatherText(int code) {
            return code switch {
                0 => "快晴",
                1 => "晴れ",
                2 => "一部曇り",
                3 => "曇り",

                45 => "霧",
                48 => "霧",

                51 => "弱い霧雨",
                53 => "霧雨",
                55 => "強い霧雨",

                61 => "小雨",
                63 => "雨",
                65 => "大雨",

                71 => "小雪",
                73 => "雪",
                75 => "大雪",

                95 => "雷雨",

                _ => "不明"
            };
        }
    }
}