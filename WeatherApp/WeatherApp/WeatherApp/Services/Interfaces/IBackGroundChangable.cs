using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WeatherApp.Services.Interfaces
{
    public interface IBackGroundChangable
    {
        void ChangeBackground(Color newColor);
    }
}
