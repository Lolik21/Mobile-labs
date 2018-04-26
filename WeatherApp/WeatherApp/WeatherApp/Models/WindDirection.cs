using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
