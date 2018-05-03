using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CitiesMasterDetailPage : MasterDetailPage
    {
        private IContentProvider contentProvider = ServiceLocator.Current.GetInstance<IContentProvider>();
        private AppSettingsController appSettings = ServiceLocator.Current.GetInstance<AppSettingsController>();
        private AppLanguageController appLanguage = ServiceLocator.Current.GetInstance<AppLanguageController>();

        public CitiesMasterDetailPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            //var city = contentProvider.Cities.First();           
            //var page = (Page)Activator.CreateInstance(typeof(CitiesMasterDetailPageDetail), city);
            Detail = new NavigationPage(new LoadingContentPage());
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is CityTableCellViewModel model)
            {
                var city = contentProvider.Cities.First((item) => item.WeatherId == model.WeatherId);
                var page = (Page)Activator.CreateInstance(typeof(CitiesMasterDetailPageDetail), city);

                Detail = new NavigationPage(page);
                IsPresented = false;

                MasterPage.ListView.SelectedItem = null;
            }
        }
    }
}