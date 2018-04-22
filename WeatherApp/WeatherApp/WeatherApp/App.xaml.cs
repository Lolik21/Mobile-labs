using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;
using Unity.ServiceLocation;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;

namespace WeatherApp
{
	public partial class App : Application
	{
        public App ()
		{
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterSingleton<AppSettingsController>();
            unityContainer.RegisterSingleton<AppLanguageProvider>();
            unityContainer.RegisterSingleton<IContentProvider, AppNetworkContentProvider>();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));

            InitializeComponent();           
			MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
