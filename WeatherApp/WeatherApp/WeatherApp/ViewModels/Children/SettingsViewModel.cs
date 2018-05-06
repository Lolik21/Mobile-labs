using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using WeatherApp.Helpers;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    class SettingsViewModel : MainViewModel, IFontChangable, IMultilangual, 
        INotifyPropertyChanged, IBackGroundChangable
    {
        protected double defaultSize = (double)Application.Current.Resources["defultSettingsFontSize"];
        protected double defaultSupportTitleSize = (double)Application.
            Current.Resources["defultSettingsFontSupportSize"];

        public SettingsViewModel(AppLanguageController appLanguageProvider)
        {
            UpdateLanguage();
            SettingsLabelsFontSize = defaultSize;
            SupportTitalFontSize = defaultSupportTitleSize;
            FontColor = defaultColor;
            BackgroundColor = backgroundColor;
            SupportedLanguages = new List<string>(appLanguageProvider.SupportedLanguages.Values);
            SelectedLanguage = appLanguageProvider.CurrentLanguage;
        }

        public string SettingsSupportTitle { get; set; }
        public string SettingsLanguageLabelText { get; set; } 
        public string SettingsFontSizeLabelText { get; set; } 
        public string SettingsFontColorLabelText { get; set; }
        public string SettingsBackgroundColorLabelText { get; set; }

        public double SupportTitalFontSize { get; set; }
        public double SettingsLabelsFontSize { get; set; }
        public List<string> SupportedLanguages { get; set; }
        public string SelectedLanguage { get; set; }

        public void UpdateFontColor(Color color)
        {
            FontColor = color;
            OnPropertyChanged("FontColor");
        }

        public void UpdateFontSize(double delta)
        {
            SettingsLabelsFontSize =  defaultSize + delta;
            SupportTitalFontSize = defaultSupportTitleSize + delta;           
            OnPropertyChanged("SupportTitalFontSize");
            OnPropertyChanged("SettingsLabelsFontSize");
        }

        public void ChangeBackground(Color newColor)
        {
            BackgroundColor = newColor;
            OnPropertyChanged("BackgroundColor");
        }

        public void UpdateLanguage()
        {
            Title = Localizer.GetString("SettingsTitle");
            SettingsSupportTitle = Localizer.GetString("SettingsSupportTitle"); ;
            SettingsLanguageLabelText = Localizer.GetString("SettingsLanguageLabelText");
            SettingsFontSizeLabelText = Localizer.GetString("SettingsFontSizeLabelText");
            SettingsFontColorLabelText = Localizer.GetString("SettingsFontColorLabelText");
            SettingsBackgroundColorLabelText = Localizer.GetString("SettingsBackgroundColorLabelText");
            OnPropertyChanged("Title");
            OnPropertyChanged("SettingsSupportTitle");
            OnPropertyChanged("SettingsLanguageLabelText");
            OnPropertyChanged("SettingsFontSizeLabelText");
            OnPropertyChanged("SettingsFontColorLabelText");
            OnPropertyChanged("SettingsBackgroundColorLabelText");
        }
       
    }
}
