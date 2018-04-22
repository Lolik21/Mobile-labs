using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    class MainMapViewModel : MainViewModel, IFontChangable, IMultilangual, 
        INotifyPropertyChanged, IBackGroundChangable
    {
        public MainMapViewModel(AppLanguageProvider appLenguageProvider)
        {
            Title = "Карта";
            SupportLabel = "Карта со всеми городами";
            SupportTitalFontSize = defaultSupportTitleSize;
            FontColor = defaultColor;
            BackgroundColor = backgroundColor;
        }
        public string SupportLabel { get; set; }
        public double SupportTitalFontSize { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

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
            SupportTitalFontSize = defaultSupportTitleSize + delta;
            OnPropertyChanged("SupportTitalFontSize");
        }

        public void UpdateLanguage()
        {
            throw new NotImplementedException();
        }
    }
}
