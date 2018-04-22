using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public abstract class MainViewModel
    {
        protected Color defaultColor = (Color)Application.Current.Resources["defultSettingsFontColor"];
        protected double defaultSize = (double)Application.Current.Resources["defultSettingsFontSize"];
        protected double defaultSupportTitleSize = (double)Application.
            Current.Resources["defultSettingsFontSupportSize"];
        protected Color backgroundColor = (Color)Application.Current.Resources["backgroundColor"];

        public string Title { get; set; }
        public string Icon { get; set; }
        public Color FontColor { get; set; }
        public Color BackgroundColor { get; set; }
        
    }
}
