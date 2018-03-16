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
	public partial class LinkResourceView : ContentPage
	{
		public LinkResourceView (string link)
		{
            Title = "Resource";
			InitializeComponent ();
            var urlWebviewSource = new UrlWebViewSource { Url = link };
            resourceWebView.Source = urlWebviewSource;
		}
	}
}