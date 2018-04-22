using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using WeatherApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsContentPage : ContentPage
    {
        private AppSettingsController appSettings = ServiceLocator.Current.GetInstance<AppSettingsController>();
        private AppLanguageProvider appLanguage = ServiceLocator.Current.GetInstance<AppLanguageProvider>();
        public SettingsContentPage()
        {
            InitializeComponent();
            SettingsViewModel settingsViewModel = new SettingsViewModel(appLanguage);
            this.BindingContext = settingsViewModel;
            appSettings.FontChangableViewModels.Add(settingsViewModel);
            appSettings.BackGroundChangableViewModels.Add(settingsViewModel);
            Color fontColor = (Color)Application.Current.Resources["defultSettingsFontColor"];
            textRedSlider.Value = fontColor.R;
            textGreenSlider.Value = fontColor.G;
            textBlueSlider.Value = fontColor.B;          
            backGroundRedSlider.Value = 1;
            backGroundGreenSlider.Value = 1;
            backGroundBlueSlider.Value = 1;
        }

        private void FontSizeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            appSettings.ChangeFontSize(e.NewValue - fontSizeSlider.Maximum / 2);
        }

        private void TextColorRedSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            appSettings.ChangeFontColor(Color.FromRgb(e.NewValue, 
                textGreenSlider.Value, textBlueSlider.Value));
        }

        private void TextColorGreenSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            appSettings.ChangeFontColor(Color.FromRgb(textRedSlider.Value, 
                e.NewValue, textBlueSlider.Value));
        }

        private void TextColorBlueSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            appSettings.ChangeFontColor(Color.FromRgb(textRedSlider.Value, 
                textGreenSlider.Value, e.NewValue));
        }

        private void backGroundRedSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            appSettings.ChangeBackgroundColor(Color.FromRgb(e.NewValue, backGroundGreenSlider.Value,
                backGroundBlueSlider.Value));
        }

        private void backGroundGreenSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            appSettings.ChangeBackgroundColor(Color.FromRgb(backGroundRedSlider.Value,
                e.NewValue, backGroundBlueSlider.Value));
        }

        private void backGroundBlueSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            appSettings.ChangeBackgroundColor(Color.FromRgb(backGroundRedSlider.Value,
                backGroundGreenSlider.Value, e.NewValue));
        }
    }
}