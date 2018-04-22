using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WeatherApp.Services.Interfaces
{
    public interface IFontChangable
    {
        void UpdateFontColor(Color color);
        void UpdateFontSize(double delta);
    }
}
