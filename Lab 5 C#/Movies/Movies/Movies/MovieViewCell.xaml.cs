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
	public partial class MovieViewCell : ViewCell
	{
        public MovieViewCell(Movie movie)
        {
            InitializeComponent();
            filmSmallImage.Source = movie.Path + ".jpg";             
            filmSmallTitle.Text = movie.Title;
            filmSmallRating.Text = movie.Rating;
            filmShortDescription.Text = movie.Description;
        }
	}
}