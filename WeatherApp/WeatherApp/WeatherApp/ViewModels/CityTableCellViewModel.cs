using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class CityTableCellViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Weather { get; set; }
        public string Description { get; set; }
        public string WeatherId { get; set; }
        public string ImageUrl { get; set; }
        public ImageSource CitySmallImageSource { get; set; }
        public ImageSource WindDirectionImageSource { get; set; }

        public CityTableCellViewModel()
        {
            CitySmallImageSource = "defaultImage.png";
        }

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
