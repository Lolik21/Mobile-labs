using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Entity
{
    public class Movie
    {
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Release { get; set; }
        public string Genres { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Path { get; set; }
    }
}
