using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public abstract class MainViewModel : INotifyPropertyChanged
    {
        protected Color defaultColor = (Color)Application.Current.Resources["defultSettingsFontColor"];        
        protected Color backgroundColor = (Color)Application.Current.Resources["backgroundColor"];

        public string Title { get; set; }
        public string Icon { get; set; }
        public Color FontColor { get; set; }
        public Color BackgroundColor { get; set; }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
