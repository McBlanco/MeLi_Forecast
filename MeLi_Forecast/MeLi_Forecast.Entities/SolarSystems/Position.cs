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
            return $"{{\"x\": {this.X.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}, \"y\": {this.Y.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}}}";
        }
    }
}
