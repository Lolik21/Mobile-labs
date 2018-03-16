using Movies.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Model
{
    class MainViewModel
    {
        private const string _jsonResPath = "https://api.myjson.com/bins/6j619";
        public List<Movie> Movies { get; set; }

        public async Task GetMoviesAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(_jsonResPath);
                Movies = JsonConvert.DeserializeObject<RootObject>(json).Movies;
            }
        }
    }
}
