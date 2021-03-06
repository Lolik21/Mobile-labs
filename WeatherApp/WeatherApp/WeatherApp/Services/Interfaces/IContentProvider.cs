﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using Xamarin.Forms;

namespace WeatherApp.Services.Interfaces
{
    public interface IContentProvider
    {
        List<City> Cities { get; set; }
        event EventHandler WeatherUpdated;
        Task LoadCities();
        string GetBigImage(City city);
        string GetSmallImage(City city);
        void GetImagesForCells(ObservableCollection<CityTableCellViewModel> citiesModels);
        Task LoadWeatherForModels(ObservableCollection<CityTableCellViewModel> citiesModels);
    }
}
