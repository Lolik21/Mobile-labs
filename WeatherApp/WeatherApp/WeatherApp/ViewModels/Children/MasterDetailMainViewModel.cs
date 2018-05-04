using System;
using System.Collections.Generic;
using System.Text;
using DewCore.Xamarin.Localization;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.ViewModels.Children
{
    class MasterDetailMainViewModel : MainViewModel, IMultilangual
    {
        public MasterDetailMainViewModel()
        {
            Title = _.GetString("MasterDetailTitle");
        }

        public void UpdateLanguage()
        {
            Title = _.GetString("MasterDetailTitle");
            OnPropertyChanged("Title");
        }
    }
}
