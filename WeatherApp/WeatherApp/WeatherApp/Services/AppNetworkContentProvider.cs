using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;

namespace WeatherApp.Services
{
    class AppNetworkContentProvider : IContentProvider
    {
        public async Task<Image> GetImage(string url)
        {
            return null; 
        }

        public async Task<string> GetJson(string url)
        {
            return null;

            //using (var httpClient = new HttpClient())
            //{
            //    Task<string> getStringTask = httpClient.GetStringAsync(UrlResolver.ResolveCitiesJsonLink());
            //    Task.WaitAll(getStringTask);
            //    string rez = getStringTask.Result;
            //    string rekf;
            //    try
            //    {
            //        List<City> cities = JsonConvert.DeserializeObject<List<City>>(rez);
            //    }
            //    catch (Exception ex)
            //    {
            //        rekf = ex.Message + "2";
            //    }

            //}
        }
    }
}
