﻿using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Unity;
using Unity.ServiceLocation;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;
using System.Net.Http;
using WeatherApp.Helpers;
using System.Threading.Tasks;
using System.Threading;
using WeatherApp.Controls;
using TK.CustomMap;

namespace WeatherApp
{
	public partial class App : Application
	{
        public App ()
		{
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterSingleton<AppSettingsController>();
            unityContainer.RegisterSingleton<AppLanguageController>();
            unityContainer.RegisterSingleton<IContentProvider, AppNetworkContentProvider>();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));
            InitializeComponent();

            AppLanguageController appLanguage = ServiceLocator.Current.GetInstance<AppLanguageController>();
            IContentProvider contentProvider = ServiceLocator.Current.GetInstance<IContentProvider>();
            


            if (!appLanguage.SupportedLanguages.ContainsKey
                (CultureInfo.CurrentCulture.Name.ToLower()))
            {
                Localizer.CultureStringOverride = 
                    appLanguage.SupportedLanguages.Keys.First();
                appLanguage.CurrentLanguage = appLanguage.
                    SupportedLanguages[appLanguage.SupportedLanguages.Keys.First()];
            }
            {
                appLanguage.CurrentLanguage = appLanguage.
                    SupportedLanguages[CultureInfo.CurrentCulture.Name.ToLower()];
            }
            Task.WaitAll(Localizer.LoadDictionary());

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
