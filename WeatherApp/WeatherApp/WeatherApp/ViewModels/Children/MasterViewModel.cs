using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;
using DewCore.Xamarin.Localization;

namespace WeatherApp.ViewModels
{
    class MasterViewModel : MainViewModel, INotifyPropertyChanged, IFontChangable, IBackGroundChangable, IMultilangual
    {
        public ObservableCollection<City> CityMenuItems { get; set; }

        public MasterViewModel()
        {
            CityMenuItems = new ObservableCollection<City>();
            Title = _.GetString("MasterDetailTitle");
        }

        public void AddRange(List<City> cities)
        {
            foreach (var city in cities)
            {
                CityMenuItems.Add(city);
            }
        }
        public void UpdateFontColor(Color color)
        {
            FontColor = color;
            OnPropertyChanged("FontColor");
        }

        public void UpdateFontSize(double delta)
        {

        }

        public void ChangeBackground(Color newColor)
        {
            BackgroundColor = newColor;
            OnPropertyChanged("BackgroundColor");
        }

        public void UpdateLanguage()
        {
            Title = _.GetString("MasterDetailTitle");
            OnPropertyChanged("Title");
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
