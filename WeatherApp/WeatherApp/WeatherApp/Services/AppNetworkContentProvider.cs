using FFImageLoading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Helpers;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp.Services
{
    class AppNetworkContentProvider : IContentProvider
    {
        public List<City> Cities { get; set; }

        public event EventHandler WeatherUpdated;

        public void GetImagesForCells(ObservableCollection<CityTableCellViewModel> citiesModels)
        {
            var httpClient = new HttpClient();
            foreach (var cityModel in citiesModels)
            {
                cityModel.CitySmallImageSource = UrlResolver.ResolveImageUrl(cityModel.ImageUrl);
                cityModel.UpdateImage();
            }
        }

        public async Task LoadCities()
        {
            if (Cities == null)
            {
                var httpClient = new HttpClient();
                try
                {
                    var json = await httpClient.GetStringAsync(UrlResolver.ResolveCitiesJsonLink());
                    this.Cities = JsonConvert.DeserializeObject<List<City>>(json);
                }
                catch(Exception e)
                {
                    Debug.Fail(e.Message);
                }                
            }
        }

        public string GetBigImage(City city)
        {
            return UrlResolver.ResolveImageUrl(city.BigPhoto);
        }

        public async Task LoadWeatherForModels(ObservableCollection<CityTableCellViewModel> citiesModels)
        {
            using (var httpClient = new HttpClient())
            {
                foreach (var cityModel in citiesModels)
                {
                    try
                    {
                        string url = UrlResolver.ResolveWeatherApiUrl(cityModel.WeatherId);
                        string json = await httpClient.GetStringAsync(url);
                        var data = JObject.Parse(json);
                        int temp = data["main"]["temp"].Value<int>();
                        var selectedCity = Cities.First((item) => item.WeatherId == cityModel.WeatherId);
                        selectedCity.CurrentWeather = Convert.ToString(temp) + " °C";
                        selectedCity.WindDegree = data["wind"]["deg"].Value<int>();
                        cityModel.Weather = selectedCity.CurrentWeather;
                        var wind = WindDirection.GetWindDirection(selectedCity.WindDegree);
                        cityModel.WindDirectionImageSource = WindDirection.GetWindImageDirection(wind);
                        cityModel.UpdateWeather();
                    }
                    catch
                    {
                        if (cityModel.WindDirectionImageSource == null)
                        {
                            cityModel.WindDirectionImageSource = WindDirection.GetNotLoadedImageDirection();
                            cityModel.UpdateWeather();
                        }
                    }                    
                }
            }
            WeatherUpdated(this, new EventArgs());
        }

        public string GetSmallImage(City city)
        {
            return UrlResolver.ResolveImageUrl(city.SmallPhoto);
        }
    }
}
