using CommonServiceLocator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Helpers;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using WeatherApp.Views;
using Xamarin.Forms;

namespace WeatherApp
{
	public partial class MainPage : TabbedPage
    {
        AppSettingsController appSettings = ServiceLocator.Current.GetInstance<AppSettingsController>();
        public MainPage()
		{
            InitializeComponent();            
        }
    }
}
