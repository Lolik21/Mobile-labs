using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;

namespace WeatherApp.ViewModels.Children
{
    class MasterDetailPageDetailViewModel : INotifyPropertyChanged, IFontChangable, IBackGroundChangable
    {
        public MasterDetailPageDetailViewModel(City city)
        {
            CityName = city.Name;
            CityWeather = city.CurrentWeather;
            CityCountry = city.Country;
            CityDescription = city.Description;
            CityWindDegree = city.WindDegree;
            BigImageSource = "defaultImage.png";
        }

        public string CityName { get; set; }
        public string CityWeather { get; set; }
        public string CityCountry { get; set; }
        public string CityDescription { get; set; }
        public int CityWindDegree { get; set; }
        public ImageSource BigImageSource { get; set; }

        public void ChangeBackground(Color newColor)
        {
            throw new NotImplementedException();
        }

        public void UpdateFontColor(Color color)
        {
            throw new NotImplementedException();
        }

        public void UpdateFontSize(double delta)
        {
            throw new NotImplementedException();
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
