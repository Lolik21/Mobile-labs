using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Services.Interfaces;
using DewCore.Xamarin.Localization;

namespace WeatherApp.Services
{
    public class AppLanguageController
    {
        public AppLanguageController()
        {
            MultilangualViewModels = new List<IMultilangual>();
        }
        public List<IMultilangual> MultilangualViewModels { get; set; }
        public Dictionary<string, string> SupportedLanguages { get; set; } = 
            new Dictionary<string, string>
        {
            {"en-us", "English" },
            {"ru-ru", "Русский" }            
        };

        public string CurrentLanguage { get; set; }

        public void UpdateLanguages(string language)
        {
            foreach(var viewModel in MultilangualViewModels)
            {
                viewModel.UpdateLanguage();
            }
        }
    }
}
