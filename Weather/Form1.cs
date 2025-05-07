using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace Weather
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public class WeatherData
        {
            [JsonPropertyName("main")]
            public MainData Main { get; set; }

            [JsonPropertyName("weather")]
            public WeatherInfo[] Weather { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("cod")]
            public int StatusCode { get; set; }
        }

        public class MainData
        {
            [JsonPropertyName("temp")]
            public double Temp { get; set; }

            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }
        }

        public class WeatherInfo
        {
            [JsonPropertyName("description")]
            public string Description { get; set; }
            [JsonPropertyName("icon")]
            public string Icon { get; set; }
        }

        private async void GetWeather()
        {
            const string apiKey = "47a6dfdce62c41c0eeecaa412e5b7720";
            string city = "Kyiv";
            if (tbTown.Text.Trim() != "")
            { city = tbTown.Text.Trim(); }
            var icoId = "01n";
            
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(
                        $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={apiKey}&lang=ru");

                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var weatherData = JsonSerializer.Deserialize<WeatherData>(json, options);


                    if (weatherData?.StatusCode != 200)
                    {
                        lblWeather.Text = "Ошибка API: " + json;
                        return;
                    }


                    if (weatherData.Main == null || weatherData.Weather == null || weatherData.Weather.Length == 0)
                    {
                        lblWeather.Text = "Неполные данные: " + json;
                        return;
                    }


                    lblWeather.Text = $"Погода в {weatherData.Name}:\n" +
                                    $"Температура: {weatherData.Main.Temp}°C\n" +
                                    $"Влажность: {weatherData.Main.Humidity}%\n" +
                                    $"Описание: {weatherData.Weather[0].Description}\n";


                    icoId = weatherData.Weather[0].Icon;
                    var imagePath = Path.Combine(Application.StartupPath, "Icon", $"{icoId}.png");
                    try
                    {
                        if (!File.Exists(imagePath))
                        {
                            throw new FileNotFoundException($"Иконка {icoId} не найдена");
                        }

                        using (var image = Image.FromFile(imagePath))
                        {
                            if (icon.InvokeRequired)
                            {
                                icon.Invoke((MethodInvoker)delegate
                                {
                                    icon.Image?.Dispose();
                                    icon.Image = new Bitmap(image);
                                });
                            }
                            else
                            {
                                icon.Image?.Dispose();
                                icon.Image = new Bitmap(image);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        lblWeather.Text += $"\nОшибка иконки: {ex.Message}";

                        // Используйте абсолютный путь для дефолтной иконки
                        var defaultPath = Path.Combine(Application.StartupPath, "Icon", "01d.png");

                        if (!File.Exists(defaultPath))
                        {
                            MessageBox.Show($"Дефолтная иконка не найдена: {defaultPath}");
                            return;
                        }

                        var defaultImage = Image.FromFile(defaultPath);
                        icon.Image = new Bitmap(defaultImage);
                        MessageBox.Show($"Путь к иконке: {imagePath}\nСуществует: {File.Exists(imagePath)}");
                    }

                }
            }
            catch (Exception ex)
            {
                lblWeather.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetWeather();
        }
    }
}