using Movies.Entity;
using Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Movies
{
	public partial class MainPage : ContentPage
	{
        private MainViewModel _mainViewModel;

        public MainPage()
		{
            Title = "Movies";
            InitializeComponent();
            InitModel();
        }

        private async void InitModel()
        {
            _mainViewModel = new MainViewModel();
            await _mainViewModel.GetMoviesAsync();
            List<Movie> movies = _mainViewModel.Movies;
            foreach (var movie in movies)
            {
                MovieViewCell movieViewCell = new MovieViewCell(movie);
                movieViewCell.Tapped += (s, args) =>
                {
                    Navigation.PushAsync(new MovieDetailPage(movie));
                };
                mainSection.Add(movieViewCell);
            }
        }
    }
}
