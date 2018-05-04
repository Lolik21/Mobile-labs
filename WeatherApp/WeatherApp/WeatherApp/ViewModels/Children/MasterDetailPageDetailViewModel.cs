using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;
using static WeatherApp.Models.WindDirection;

namespace WeatherApp.ViewModels.Children
{
    class MasterDetailPageDetailViewModel : MainViewModel, INotifyPropertyChanged, IFontChangable, IBackGroundChangable
    {
        private IContentProvider contentProvider = ServiceLocator.Current.GetInstance<IContentProvider>();
        private City city;
        protected double defultDetailTitleFontSize = (double)Application.
            Current.Resources["defultDetailTitleFontSize"];
        protected double defultDetailKeyInfoTitleFontSize = (double)Application.
            Current.Resources["defultDetailKeyInfoTitleFontSize"];
        protected double defultDetailDecriptionTitleFontSize = (double)Application.
            Current.Resources["defultDetailDecriptionTitleFontSize"];

        public MasterDetailPageDetailViewModel(City city)
        {
            this.city = city;
            BigImageSource = contentProvider.GetBigImage(city);
            OnPropertyChanged("BigImageSource");
            CityName = city.Name;
            CityWeather = city.CurrentWeather;
            CityCountry = city.Country;
            CityDescription = city.Description;          
            FontColor = defaultColor;
            BackgroundColor = backgroundColor;
            DefultDetailTitleFontSize = defultDetailTitleFontSize;
            DefultDetailKeyInfoTitleFontSize = defultDetailKeyInfoTitleFontSize;
            DefultDetailDecriptionTitleFontSize = defultDetailDecriptionTitleFontSize;
            Wind wind = GetWindDirection(city.WindDegree);
            WindDirectionImageSource = GetWindImageDirection(wind);
            contentProvider.WeatherUpdated += WeatherUpdated;
        }

        public string CityName { get; set; }
        public string CityWeather { get; set; }
        public string CityCountry { get; set; }
        public string CityDescription { get; set; }
        public string BigImageSource { get; set; }
        public ImageSource WindDirectionImageSource { get; set; }

        public double DefultDetailTitleFontSize { get; set; }
        public double DefultDetailKeyInfoTitleFontSize { get; set; }
        public double DefultDetailDecriptionTitleFontSize { get; set; }

        public void ChangeBackground(Color newColor)
        {
            this.BackgroundColor = newColor;
            OnPropertyChanged("BackgroundColor");
        }

        public void UpdateFontColor(Color color)
        {
            this.FontColor = color;
            OnPropertyChanged("FontColor");
        }

        public void UpdateFontSize(double delta)
        {
            DefultDetailTitleFontSize = defultDetailTitleFontSize + delta;
            DefultDetailKeyInfoTitleFontSize = defultDetailKeyInfoTitleFontSize + delta;
            DefultDetailDecriptionTitleFontSize = defultDetailDecriptionTitleFontSize + delta;
            OnPropertyChanged("DefultDetailTitleFontSize");
            OnPropertyChanged("DefultDetailKeyInfoTitleFontSize");
            OnPropertyChanged("DefultDetailDecriptionTitleFontSize");
        }

        private void WeatherUpdated(object sender, EventArgs e)
        {
            CityWeather = city.CurrentWeather;
            Wind wind = GetWindDirection(city.WindDegree);
            WindDirectionImageSource = GetWindImageDirection(wind);
            OnPropertyChanged("CityWeather");
            OnPropertyChanged("WindDirectionImageSource");
        }
    }
}
