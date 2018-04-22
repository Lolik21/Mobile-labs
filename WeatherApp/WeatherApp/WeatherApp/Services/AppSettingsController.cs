using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;

namespace WeatherApp.Services
{
    public class AppSettingsController
    {
        public AppSettingsController()
        {
            FontChangableViewModels = new List<IFontChangable>();
            MultilangualViewModels = new List<IMultilangual>();
            BackGroundChangableViewModels = new List<IBackGroundChangable>();
        }

        public List<IFontChangable> FontChangableViewModels { get; set; }
        public List<IMultilangual> MultilangualViewModels { get; set; }
        public List<IBackGroundChangable> BackGroundChangableViewModels { get; set; }
        
        public void ChangeFontSize(double delta)
        {
            foreach (var viewModel in FontChangableViewModels)
            {
                viewModel.UpdateFontSize(delta);
            }
        }

        public void ChangeFontColor(Color newColor)
        {
            foreach (var viewModel in FontChangableViewModels)
            {
                viewModel.UpdateFontColor(newColor);
            }
        }

        public void ChangeBackgroundColor(Color newColor)
        {
            foreach (var viewModel in BackGroundChangableViewModels)
            {
                viewModel.ChangeBackground(newColor);
            }
        }

        public void ChangeLanguage(string languageName)
        {

        }

        
    }
}
