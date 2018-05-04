using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TK.CustomMap;
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
        private City city;
        private AppSettingsController appSettings = ServiceLocator.Current.GetInstance<AppSettingsController>();
        private AppLanguageController appLanguage = ServiceLocator.Current.GetInstance<AppLanguageController>();

        public CitiesMasterDetailPageDetail(City city)
        {
            InitializeComponent();
            this.city = city;
            var masterDetailPageDetailViewModel = new MasterDetailPageDetailViewModel(city);
            BindingContext = masterDetailPageDetailViewModel;
            appSettings.BackGroundChangableViewModels.Add(masterDetailPageDetailViewModel);
            appSettings.FontChangableViewModels.Add(masterDetailPageDetailViewModel);
            cityMap.MapReady += MapReady;
        }
        
        private void MapReady(object sender, EventArgs e)
        {
            var position = new TK.CustomMap.Position(Convert.ToDouble(city.Latitude), Convert.ToDouble(city.Longitude));
            var pin = new TKCustomMapPin
            {
                Image = (this.BindingContext as MasterDetailPageDetailViewModel).WindDirectionImageSource,
                Position = position,
                Title = city.Name,
                Anchor = new Point(0, 0),
                Subtitle = city.CurrentWeather,
                IsCalloutClickable = true,
                ShowCallout = true,               
            };
            cityMap.Pins = new List<TKCustomMapPin> { pin };
            cityMap.MapRegion = MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1));
        }
    }
}