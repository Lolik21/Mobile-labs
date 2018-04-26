using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp.Services.Interfaces
{
    public interface IContentProvider
    {
        List<City> Cities { get; set; }
        Task<Image> GetImage(string imageName);
        Task LoadCities();
    }
}
