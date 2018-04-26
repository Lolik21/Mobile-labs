using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CitiesMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;
        private IContentProvider contentProvider = ServiceLocator.Current.GetInstance<IContentProvider>();
        private AppSettingsController appSettings = ServiceLocator.Current.GetInstance<AppSettingsController>();
        private AppLanguageController appLanguage = ServiceLocator.Current.GetInstance<AppLanguageController>();

        public CitiesMasterDetailPageMaster()
        {
            InitializeComponent();
            var masterViewModel = new MasterViewModel();
            BindingContext = masterViewModel;
            appLanguage.MultilangualViewModels.Add(masterViewModel);
            appSettings.BackGroundChangableViewModels.Add(masterViewModel);
            appSettings.FontChangableViewModels.Add(masterViewModel);
            InitPage();
            ListView = MenuItemsListView;
        }

        private async void InitPage()
        {
            await contentProvider.LoadCities();
            (this.BindingContext as MasterViewModel).AddRange(contentProvider.Cities);
        }
    }
}