using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK.CustomMap;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static WeatherApp.Models.WindDirection;

namespace WeatherApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMapContentPage : ContentPage
	{
        private IContentProvider contentProvider = ServiceLocator.Current.GetInstance<IContentProvider>();
        AppSettingsController appSettings = ServiceLocator.Current.GetInstance<AppSettingsController>();
        AppLanguageController appLanguage = ServiceLocator.Current.GetInstance<AppLanguageController>();
        public MainMapContentPage ()
		{
			InitializeComponent ();
            MainMapViewModel mainMapViewModel = new MainMapViewModel(appLanguage);
            this.BindingContext = mainMapViewModel;
            appSettings.BackGroundChangableViewModels.Add(mainMapViewModel);
            appSettings.FontChangableViewModels.Add(mainMapViewModel);
            appLanguage.MultilangualViewModels.Add(mainMapViewModel);
            contentProvider.WeatherUpdated += WeatherLoaded;
        }

        private void WeatherLoaded(object sender, EventArgs e)
        {
            List<TKCustomMapPin> pins = new List<TKCustomMapPin>();
            foreach (var city in contentProvider.Cities)
            {
                var position = new Position(Convert.ToDouble(city.Latitude), Convert.ToDouble(city.Longitude));
                Wind wind = GetWindDirection(city.WindDegree);
                ImageSource sorce = GetWindImageDirection(wind);
                var pin = new TKCustomMapPin
                {
                    Image = sorce,
                    Position = position,
                    Title = city.Name,
                    Anchor = new Point(0, 0),
                    Subtitle = city.CurrentWeather,
                    IsCalloutClickable = true,
                    ShowCallout = true,
                };
                pins.Add(pin);                
            }
            citiesMap.Pins = pins;

            #region GOVNOCOD
            City centerCity = contentProvider.Cities.Where((item) => item.Name == "Minsk").First();
            var centerTown = new Position(Convert.ToDouble(centerCity.Latitude), Convert.ToDouble(centerCity.Longitude));
            citiesMap.MapRegion = MapSpan.FromCenterAndRadius(centerTown, Distance.FromKilometers(300));
            #endregion
        }
    }
}