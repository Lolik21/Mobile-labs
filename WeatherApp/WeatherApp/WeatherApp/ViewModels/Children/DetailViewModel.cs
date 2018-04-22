using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    class DetailViewModel : MainViewModel
    {
        public string Title { get; set; }
        public string CityName { get; set; }
        public Image CityImage { get; set; }
        public string CityTemperature { get; set; }
        public string CityLocation { get; set; }
        public string CityDescription { get; set; }

    }
}
