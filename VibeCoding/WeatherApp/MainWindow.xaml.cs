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
                GetWeatherIcon(weather.WeatherCode));

            sb.AppendLine(
                $"{weather.Temperature}℃");

            sb.AppendLine(
                GetWeatherText(weather.WeatherCode));

            sb.AppendLine(
                $"💧{weather.Humidity}%  🌬{weather.WindSpeed}m/s");

            CurrentWeatherText.Text = sb.ToString();

            ChangeBackgroundColor(weather.WeatherCode);

            ForecastList.Items.Clear();

            foreach (var day in weather.DailyForecasts) {
                DateTime date =
                    DateTime.Parse(day.Date);

                string formattedDate =
                    date.ToString(
                        "M/d(ddd)",
                        new CultureInfo("ja-JP"));

                ForecastList.Items.Add(
                    $"{formattedDate}  " +
                    $"{GetWeatherIcon(day.WeatherCode)}  " +
                    $"{day.MaxTemperature}° / {day.MinTemperature}°");
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

        private string GetWeatherIcon(int code) {
            return code switch {
                0 => "☀",
                1 => "☀",

                2 => "⛅",
                3 => "☁",

                61 => "☂",
                63 => "☂",
                65 => "☂",

                71 => "❄",
                73 => "❄",
                75 => "❄",

                _ => "🌤"
            };
        }

        private void ChangeBackgroundColor(int weatherCode) {
            if (weatherCode == 0 || weatherCode == 1) {
                MainGrid.Background =
                    System.Windows.Media.Brushes.LightSkyBlue;

                Title = "☀ 天気予報アプリ";
            } else if (weatherCode == 2 || weatherCode == 3) {
                MainGrid.Background =
                    System.Windows.Media.Brushes.LightGray;

                Title = "☁ 天気予報アプリ";
            } else {
                MainGrid.Background =
                    System.Windows.Media.Brushes.LightSteelBlue;

                Title = "☂ 天気予報アプリ";
            }
        }
    }
}