using Movies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movies
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieDetailPage : ContentPage
	{
        private Movie _movie;
		public MovieDetailPage (Movie movie)
		{
            Title = "Movie";
			InitializeComponent ();
            imgMovieImage.Source = movie.Path + ".jpg";
            lblMovieTitle.Text = movie.Title;
            lblMovieRating.Text = movie.Rating;
            lblMovieRelease.Text = movie.Release;
            lblMovieGenres.Text = movie.Genres;
            lblMovieDescription.Text = movie.Description;
            lblMovieDuration.Text = movie.Duration;
            _movie = movie;
        }

        private void btnGoToLink_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LinkResourceView(_movie.Link));
        }
    }
}