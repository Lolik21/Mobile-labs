using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherApp.Services.Interfaces
{
    public interface IContentProvider
    {
        Task<string> GetJson(string url);
        Task<Image> GetImage(string url);
    }
}
