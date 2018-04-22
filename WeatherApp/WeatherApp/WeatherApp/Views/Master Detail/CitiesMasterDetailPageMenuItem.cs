﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Views
{

    public class CitiesMasterDetailPageMenuItem
    {
        public CitiesMasterDetailPageMenuItem()
        {
            TargetType = typeof(CitiesMasterDetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}