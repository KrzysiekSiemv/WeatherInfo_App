using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    class WeatherData
    {
        public string City { get; set; }
        public string Icon { get; set; }
        public string Background { get; set; }
        public string Description { get; set; }
        public string Temperature { get; set; }
        public string FeelLike { get; set; }
        public string MinTemp { get; set; }
        public string MaxTemp { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string Wind { get; set; }
        public string Cloudly { get; set; }

        public WeatherData(string city, string country, string description, float temperature, float feelLike, float minTemp, float maxTemp, int pressure, int humidity, float speed, int deg, int cloudly, string id)
        {
            City = $"{city}, {country}";
            Description = description;
            Temperature = string.Format("{0:F1}°C", temperature);
            FeelLike = string.Format("Odczuwalne: {0:F1}°C", feelLike);
            MinTemp = string.Format("Najniższa temp: {0:F1}°C", minTemp);
            MaxTemp = string.Format("Najwyższa temp: {0:F1}°C", maxTemp);
            Pressure = string.Format("Ciśnienie: {0} hPa", pressure);
            Humidity = string.Format("Wilgotność: {0}%", humidity);
            Wind = string.Format("Wiatr: {0:F2} m/s, {1}°", speed, deg);
            Cloudly = string.Format("Pochmurzenie: {0}%", cloudly);
            Background = $"bg{id}.jpg";
            Icon = $"https://openweathermap.org/img/wn/{id}@4x.png";
        }
    }
}
