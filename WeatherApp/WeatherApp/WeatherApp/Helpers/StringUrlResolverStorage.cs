using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Helpers
{
    public class  StringUrlResolverHelper
    {
        public static string WeatherApiKey = "0d37ddf1c560bde3380366566f6ba826";
        public static string ImagesUrl = "https://bsuir-materials.000webhostapp.com/ios/img/{0}.png";
        public static string CitiesUrl = "https://api.myjson.com/bins/z3rd3?secretPassword={0}";
        public static string WeatherApiUrl = "https://api.openweathermap.org/data/2.5/weather?id={0}&units=metric&appid={1}&secretPassword={2}";
    }
}
