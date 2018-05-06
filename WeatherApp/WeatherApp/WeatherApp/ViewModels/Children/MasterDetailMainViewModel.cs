using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Helpers;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.ViewModels.Children
{
    class MasterDetailMainViewModel : MainViewModel, IMultilangual
    {
        public MasterDetailMainViewModel()
        {
            Title = Localizer.GetString("MasterDetailTitle");
        }

        public void UpdateLanguage()
        {
            Title = Localizer.GetString("MasterDetailTitle");
            OnPropertyChanged("Title");
        }
    }
}
