using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.Helpers;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    class MainMapViewModel : MainViewModel, IFontChangable, IMultilangual, 
        INotifyPropertyChanged, IBackGroundChangable
    {
        protected double defaultMapTitleSize = (double)Application.
            Current.Resources["defultSettingsFontSupportSize"];
        public MainMapViewModel(AppLanguageController appLenguageProvider)
        {
            Title = Localizer.GetString("MapTitle");
            MapSupportTitle = Localizer.GetString("MapSupportTitle");
            SupportTitalFontSize = defaultMapTitleSize;
            FontColor = defaultColor;
            BackgroundColor = backgroundColor;
        }
        public string MapSupportTitle { get; set; }
        public double SupportTitalFontSize { get; set; }

        public void ChangeBackground(Color newColor)
        {
            BackgroundColor = newColor;
            OnPropertyChanged("BackgroundColor");
        }

        public void UpdateFontColor(Color color)
        {
            FontColor = color;
            OnPropertyChanged("FontColor");
        }

        public void UpdateFontSize(double delta)
        {
            SupportTitalFontSize = defaultMapTitleSize + delta;
            OnPropertyChanged("SupportTitalFontSize");
        }

        public void UpdateLanguage()
        {
            Title = Localizer.GetString("MapTitle");
            MapSupportTitle = Localizer.GetString("MapSupportTitle");
            OnPropertyChanged("Title");
            OnPropertyChanged("MapSupportTitle");
        }
    }
}
