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
            InitCities();
            ListView = MenuItemsListView;
        }

        private async void InitCities()
        {
            await contentProvider.LoadCities();
            var models = contentProvider.Cities.Select((item) => new CityTableCellViewModel
            {
                Name = item.Name,
                Description = item.Description,
                Weather = item.CurrentWeather,
                WeatherId = item.WeatherId,
                ImageUrl = item.SmallPhoto
            });
            (this.BindingContext as MasterViewModel).AddRange(models.ToList());
            InitImages();
            await contentProvider.LoadWeatherForModels((this.BindingContext as MasterViewModel).CityMenuItems);            
        }

        private void InitImages()
        {
            contentProvider.GetImagesForCells((this.BindingContext as MasterViewModel).CityMenuItems);
        }

        private async void MenuItemsListView_Refreshing(object sender, EventArgs e)
        {
            var model = this.BindingContext as MasterViewModel;
            model.IsRefreshing = true;
            await contentProvider.LoadWeatherForModels(model.CityMenuItems);
            model.IsRefreshing = false;
        }
    }
}