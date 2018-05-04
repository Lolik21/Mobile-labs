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
using WeatherApp.ViewModels.Children;
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

        private Dictionary<City, Page> pages = new Dictionary<City, Page>();

        public CitiesMasterDetailPage()
        {
            InitializeComponent();
            var masterModel = new MasterDetailMainViewModel();
            this.BindingContext = masterModel;
            appLanguage.MultilangualViewModels.Add(masterModel);
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            contentProvider.WeatherUpdated += WeatherLoaded;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is CityTableCellViewModel model)
            {
                var city = contentProvider.Cities.First((item) => item.WeatherId == model.WeatherId);
                if (!pages.ContainsKey(city))
                {
                    var page = (Page)Activator.CreateInstance(typeof(CitiesMasterDetailPageDetail), city);
                    pages.Add(city, page);
                }  
                Detail = new NavigationPage(pages[city]);
                IsPresented = false;
                MasterPage.ListView.SelectedItem = null;
            }
        }

        private void WeatherLoaded(object sender, EventArgs e)
        {
            var city = contentProvider.Cities.First();
            if (!pages.ContainsKey(city))
            {
                var page = (Page)Activator.CreateInstance(typeof(CitiesMasterDetailPageDetail), city);
                pages.Add(city, page);
            }
            Detail = new NavigationPage(pages[city]);
            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;
            contentProvider.WeatherUpdated -= WeatherLoaded;
        }
    }
}