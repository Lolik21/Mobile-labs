using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string SmallPhoto { get; set; }
        public string BigPhoto { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string WeatherId { get; set; }

        public string CurrentWeather { get; set; }
    }
}
