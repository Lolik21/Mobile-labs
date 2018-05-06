using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingContentPage : ContentPage
	{
		public LoadingContentPage ()
		{
			InitializeComponent();
		}
	}
}