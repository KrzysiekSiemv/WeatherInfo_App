using System.Net;
using System.Text.Json;

namespace Weather
{
    public partial class MainPage : ContentPage
    {
        string api_key = "a907c532735513e696815ef722a3d345", type = "id", city = "3093133";
        WeatherViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new WeatherViewModel(api_key, city, type);
            BindingContext = viewModel;
            
        }
    }
}
