using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Windows.Input;

namespace Weather
{
    class WeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private WeatherData _weather;
        public WeatherData WeatherData { 
            get { return _weather; } 
            set { 
                _weather = value;
                OnPropertyChanged(nameof(WeatherData));
            } 
        }

        public WeatherViewModel(string api_key, string city, string type) => LoadData(api_key, city, type);

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        async void LoadData(string api_key, string city, string type) {
            using (HttpClient web = new())
            {
                try
                {
                    var response = await web.GetAsync($"https://api.openweathermap.org/data/2.5/weather?{type}={city}&appid={api_key}&units=metric&lang=pl");
                    if (response.IsSuccessStatusCode)
                    {
                        JsonDocument json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                        JsonElement root = json.RootElement;

                        string cityName = root.GetProperty("name").GetString();
                        JsonElement sys = root.GetProperty("sys");
                        string country = sys.GetProperty("country").GetString();
                        JsonElement weather = root.GetProperty("weather")[0];
                        string description = weather.GetProperty("description").GetString();
                        JsonElement main = root.GetProperty("main");
                        float temperature = main.GetProperty("temp").GetSingle();
                        float feelsLike = main.GetProperty("feels_like").GetSingle();
                        float minTemp = main.GetProperty("temp_min").GetSingle();
                        float maxTemp = main.GetProperty("temp_max").GetSingle();
                        int pressure = main.GetProperty("pressure").GetInt32();
                        int humidity = main.GetProperty("humidity").GetInt32();
                        JsonElement wind = root.GetProperty("wind");
                        float speed = wind.GetProperty("speed").GetSingle();
                        int deg = wind.GetProperty("deg").GetInt32();
                        JsonElement clouds = root.GetProperty("clouds");
                        int cloudiness = clouds.GetProperty("all").GetInt32();
                        string id = weather.GetProperty("icon").GetString();

                        WeatherData = new WeatherData(cityName, country, description, temperature, feelsLike, minTemp, maxTemp, pressure, humidity, speed, deg, cloudiness, id);
                    }
                } catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
