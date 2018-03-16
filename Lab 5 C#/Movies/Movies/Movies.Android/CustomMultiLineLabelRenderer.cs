using Movies.Droid;
using Movies.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MultiLineLabel), typeof(CustomMultiLineLabelRenderer))]
namespace Movies.Droid
{
    public class CustomMultiLineLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);
            MultiLineLabel multiLineLabel = (MultiLineLabel)Element;

            if (multiLineLabel != null && multiLineLabel.Lines != -1)
            {
                Control.SetSingleLine(false);
                Control.SetMaxLines(multiLineLabel.Lines);
                Control.SetLines(multiLineLabel.Lines);
            }
        }
    }
}