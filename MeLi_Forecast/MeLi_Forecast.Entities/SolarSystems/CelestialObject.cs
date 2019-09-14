using System;
using System.Collections.Generic;
using System.Text;

namespace MeLi_Forecast.Entities.SolarSystems
{
    public class CelestialObject
    {
        public string Name { get; set; }
        public double Diameter { get; set; }

        public CelestialObject()
        {
            this.Name = null;
            this.Diameter = 0;
        }

        public CelestialObject(string name, double diameter)
        {
            this.Name = name;
            this.Diameter = diameter;
        }

        public virtual Position GetPosition(double angle)
        {
            return new Position();
        }
    }
}
