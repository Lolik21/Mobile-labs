using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMapContentPage : ContentPage
	{
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
        }
	}
}