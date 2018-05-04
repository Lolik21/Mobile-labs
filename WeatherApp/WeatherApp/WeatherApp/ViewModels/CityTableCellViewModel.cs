using CommonServiceLocator;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class CityTableCellViewModel : INotifyPropertyChanged
    {
        private IContentProvider contentProvider = ServiceLocator.Current.GetInstance<IContentProvider>();

        public CityTableCellViewModel(City city)
        {
            CitySmallImageSource = contentProvider.GetSmallImage(city);
        }

        public string Name { get; set; }
        public string Weather { get; set; }
        public string Description { get; set; }
        public string WeatherId { get; set; }
        public string ImageUrl { get; set; }
        public string CitySmallImageSource { get; set; }
        public ImageSource WindDirectionImageSource { get; set; }

        public void UpdateImage()
        {
            OnPropertyChanged("CitySmallImageSource");
        }
        public void UpdateWeather()
        {
            OnPropertyChanged("Weather");
            OnPropertyChanged("WindDirectionImageSource");
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
