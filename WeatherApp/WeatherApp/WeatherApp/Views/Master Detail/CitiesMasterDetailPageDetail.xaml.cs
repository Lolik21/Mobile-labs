using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels.Children;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CitiesMasterDetailPageDetail : ContentPage
    {
        private IContentProvider contentProvider = ServiceLocator.Current.GetInstance<IContentProvider>();
        private AppSettingsController appSettings = ServiceLocator.Current.GetInstance<AppSettingsController>();
        private AppLanguageController appLanguage = ServiceLocator.Current.GetInstance<AppLanguageController>();

        public CitiesMasterDetailPageDetail(City city)
        {
            InitializeComponent();
            var masterDetailPageDetailViewModel = new MasterDetailPageDetailViewModel(city);
            BindingContext = masterDetailPageDetailViewModel;
        }
    }
}