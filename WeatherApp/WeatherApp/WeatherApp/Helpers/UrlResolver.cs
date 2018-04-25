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
    }
}
