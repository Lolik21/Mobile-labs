using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Helpers
{
    static class UrlResolver
    {
        public static string ResolveCitiesJsonLink()
        {
            return string.Format(StringUrlResolverHelper.CitiesUrl, Guid.NewGuid().ToString());
        }

        public static string ResolveWeatherApiUrl(string cityId)
        {
            return string.Format(StringUrlResolverHelper.WeatherApiUrl,
                cityId, StringUrlResolverHelper.WeatherApiKey, Guid.NewGuid().ToString());
        }

        public static string ResolveImageUrl(string imageName)
        {
            return string.Format(StringUrlResolverHelper.ImagesUrl, imageName);
        }
    }
}
