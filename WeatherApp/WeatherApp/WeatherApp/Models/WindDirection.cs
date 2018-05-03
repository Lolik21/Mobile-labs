using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WeatherApp.Models
{
    public class WindDirection
    {
        public enum Wind
        {
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest         
        }

        public static Wind GetWindDirection(int grade)
        {
            if (grade >= 339 && grade <= 360)
            {
                return Wind.North;
            }
            if (grade >= 0 && grade <= 23)
            {
                return Wind.North;
            }
            if (grade >= 24 && grade <= 68)
            {
                return Wind.NorthEast;
            }
            if (grade >= 69 && grade <= 113)
            {
                return Wind.East;
            }
            if (grade >= 114 && grade <= 158)
            {
                return Wind.SouthEast;
            }
            if (grade >= 159 && grade <= 203)
            {
                return Wind.South;
            }
            if (grade >= 204 && grade <= 248)
            {
                return Wind.SouthWest;
            }
            if (grade >= 249 && grade <= 293)
            {
                return Wind.West;
            }
            if (grade >= 294 && grade <= 338)
            {
                return Wind.NorthWest;
            }
            return Wind.North;
        }

        public static ImageSource GetWindImageDirection(Wind wind)
        {
            switch (wind)
            {
                case Wind.North:
                    return "north.png";
                case Wind.NorthEast:
                    return "northeast.png";
                case Wind.East:
                    return "east.png";
                case Wind.SouthEast:
                    return "southeast.png";
                case Wind.South:
                    return "south.png";
                case Wind.SouthWest:
                    return "southwest.png";
                case Wind.West:
                    return "west.png";
                case Wind.NorthWest:
                    return "northwest.png";
                default:
                    return "cross.png";
            }
        }
        public static ImageSource GetNotLoadedImageDirection()
        {
            return "cross.png";
        }
    }
}
