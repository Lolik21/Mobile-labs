using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WeatherApp.Controls;
using WeatherApp.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GifImageViewControl), typeof(GifImageViewRenderer))]
namespace WeatherApp.Droid.Renders
{
    #pragma warning disable CS0618 // Тип или член устарел
                                  /// <summary>
                                  /// GifImageView Renderer
                                  /// </summary>
    public class GifImageViewRenderer : ViewRenderer<Image, Felipecsl.GifImageViewLibrary.GifImageView>
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

        Felipecsl.GifImageViewLibrary.GifImageView gif;
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
                return;

            gif = new Felipecsl.GifImageViewLibrary.GifImageView(Forms.Context);

            SetNativeControl(gif);
        }

        static async Task<byte[]> GetBytesFromStreamAsync(Stream stream)
        {
            using (stream)
            {
                if (stream == null || stream.Length == 0)
                    return null;

                var bytes = new byte[stream.Length];
                if (await stream.ReadAsync(bytes, 0, (int)stream.Length) > 0)
                    return bytes;
            }

            return null;
        }

        bool loaded;
        protected override async void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Image.SourceProperty.PropertyName)
            {
                byte[] bytes = null;

                var s = Element.Source;
                if (s is UriImageSource)
                {
                    using (var client = new HttpClient())
                        bytes = await client.GetByteArrayAsync(((UriImageSource)s).Uri);
                }
                else if (s is StreamImageSource)
                {
                    bytes = await GetBytesFromStreamAsync(await ((StreamImageSource)s).Stream(default(CancellationToken)));
                }
                else if (s is FileImageSource)
                {
                    bytes = await GetBytesFromStreamAsync(File.OpenRead(((FileImageSource)s).File));
                }

                if (bytes == null)
                    return;

                try
                {
                    gif.StopAnimation();
                    gif.SetBytes(bytes);
                    gif.StartAnimation();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Unable to load gif: " + ex.Message);
                }

            }
        }
    }
#pragma warning restore CS0618 // Тип или член устарел
}