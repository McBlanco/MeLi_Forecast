using System;
using System.Collections.Generic;
using System.Text;

namespace MeLi_Forecast.Entities.SolarSystems
{
    public class Planet: CelestialObject
    {
        public bool IsClockwise { get; set; }
        public double Traslation { get; set; }
        public double Distance { get; set; }

        public Planet(): base()
        {
            this.IsClockwise = false;
            this.Traslation = 0;
            this.Distance = 0;
        }

        public Planet (string name, double diameter, bool isClockwise, double traslation, double distance): base(name, diameter)
        {
            this.IsClockwise = isClockwise;
            this.Traslation = traslation;
            this.Distance = distance;
        }
    }
}
