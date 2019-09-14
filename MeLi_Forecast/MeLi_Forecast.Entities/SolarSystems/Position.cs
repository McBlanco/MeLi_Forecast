using System;
using System.Collections.Generic;
using System.Text;

namespace MeLi_Forecast.Entities.SolarSystems
{
    public class Position
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Position()
        {
            this.X = 0;
            this.Y = 0;
        }

        public override string ToString()
        {
            return $"{{x: {this.X}, y: {this.Y}}}";
        }
    }
}
