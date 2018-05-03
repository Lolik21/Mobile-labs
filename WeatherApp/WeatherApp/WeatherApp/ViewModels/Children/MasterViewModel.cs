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
using System.Windows.Input;

namespace WeatherApp.ViewModels
{
    class MasterViewModel : MainViewModel, INotifyPropertyChanged, IFontChangable, IBackGroundChangable, IMultilangual
    {
        private bool _isRefreshing = false;

        protected double masterCityTitleLabelFontSize = 
            (double)Application.Current.Resources["masterCityTitleLabelFontSize"];
        protected double masterCityWeatherLabelFontSize =
            (double)Application.Current.Resources["masterCityWeatherLabelFontSize"];
        protected double masterCityDescriptionLabelFontSize =
            (double)Application.Current.Resources["masterCityDescriptionLabelFontSize"];

        public MasterViewModel()
        {
            CityMenuItems = new ObservableCollection<CityTableCellViewModel>();
            Title = _.GetString("MasterDetailTitle");
            MasterCityTitleLabelFontSize = masterCityTitleLabelFontSize;
            MasterCityWeatherLabelFontSize = masterCityWeatherLabelFontSize;
            MasterCityDescriptionLabelFontSize = masterCityDescriptionLabelFontSize;
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ObservableCollection<CityTableCellViewModel> CityMenuItems { get; set; }

        public double MasterCityTitleLabelFontSize { get; set; }
        public double MasterCityWeatherLabelFontSize { get; set; }
        public double MasterCityDescriptionLabelFontSize { get; set; }

        public void AddRange(List<CityTableCellViewModel> citiesCells)
        {
            foreach (var cityCell in citiesCells)
            {
                CityMenuItems.Add(cityCell);
            }
        }
        public void UpdateFontColor(Color color)
        {
            FontColor = color;
            OnPropertyChanged("FontColor");
        }

        public void UpdateFontSize(double delta)
        {
            MasterCityTitleLabelFontSize = masterCityTitleLabelFontSize + delta;
            MasterCityWeatherLabelFontSize = masterCityWeatherLabelFontSize + delta;
            MasterCityDescriptionLabelFontSize = masterCityDescriptionLabelFontSize + delta;
            OnPropertyChanged("MasterCityTitleLabelFontSize");
            OnPropertyChanged("MasterCityWeatherLabelFontSize");
            OnPropertyChanged("MasterCityDescriptionLabelFontSize");
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
