using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    class SettingsViewModel : MainViewModel, IFontChangable, IMultilangual, 
        INotifyPropertyChanged, IBackGroundChangable
    {
        public SettingsViewModel(AppLanguageProvider appLenguageProvider)
        {
            Title = "Настройки";
            SupportTitle = "Страница настроек. Тут вы можете " +
            "изменять настройки в приложении и они будут сразу обновляться!";
            AppLanguageLabelText = "Язык приложения";
            AppFontSizeLabelText = "Размер шрифта";
            AppFontColorLabelText = "Цвет шрифта";
            AppBackgroundColorLabelText = "Цвет фона";
            SettingsLabelsFontSize = defaultSize;
            SupportTitalFontSize = defaultSupportTitleSize;
            FontColor = defaultColor;
            BackgroundColor = backgroundColor;
        }

        public string SupportTitle { get; set; }
        public string AppLanguageLabelText { get; set; } 
        public string AppFontSizeLabelText { get; set; } 
        public string AppFontColorLabelText { get; set; }
        public string AppBackgroundColorLabelText { get; set; }
        public double SupportTitalFontSize { get; set; }
        public double SettingsLabelsFontSize { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public void UpdateFontColor(Color color)
        {
            FontColor = color;
            OnPropertyChanged("FontColor");
        }

        public void UpdateFontSize(double delta)
        {
            SettingsLabelsFontSize =  defaultSize + delta;
            SupportTitalFontSize = defaultSupportTitleSize + delta;
            OnPropertyChanged("SettingsLabelsFontSize");
            OnPropertyChanged("SupportTitalFontSize");
        }

        public void ChangeBackground(Color newColor)
        {
            BackgroundColor = newColor;
            OnPropertyChanged("BackgroundColor");
        }

        public void UpdateLanguage()
        {
            throw new NotImplementedException();
        }
       
    }
}
