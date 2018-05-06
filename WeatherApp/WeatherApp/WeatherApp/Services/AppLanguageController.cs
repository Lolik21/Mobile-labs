using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Services.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;
using WeatherApp.Helpers;

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

        public async Task UpdateLanguages(string language)
        {
            var newCulture = new CultureInfo(SupportedLanguages.
                First(x => x.Value == language).Key);
            var prevCulture = new CultureInfo(SupportedLanguages.
                First(x => x.Value == CurrentLanguage).Key);

            if (newCulture.Name.ToLower() != prevCulture.Name.ToLower())
            {
                await Localizer.ChangeCulture(newCulture);

                foreach (var viewModel in MultilangualViewModels)
                {
                    viewModel.UpdateLanguage();
                }

                CurrentLanguage = SupportedLanguages[newCulture.Name.ToLower()];
            }        
        }
    }
}
