using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Helpers;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;

namespace WeatherApp.Services
{
    class AppNetworkContentProvider : IContentProvider
    {
        public List<City> Cities { get; set; }
        public async Task<Image> GetImage(string url)
        {
            return null; 
        }

        public async Task LoadCities()
        {
            if (Cities == null)
            {
                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync(UrlResolver.ResolveCitiesJsonLink());                
                    this.Cities = JsonConvert.DeserializeObject<List<City>>(json);
                }                
            }
        }
    }
}
