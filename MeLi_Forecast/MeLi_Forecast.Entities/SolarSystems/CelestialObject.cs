using System;
using System.Collections.Generic;
using System.Text;

namespace MeLi_Forecast.Entities.SolarSystems
{
    public class CelestialObject
    {
        public string Name { get; set; }

        public CelestialObject()
        {
            this.Name = null;
        }

        public CelestialObject(string name)
        {
            this.Name = name;
        }

        public virtual Position GetPosition(double day)
        {
            return new Position();
        }
    }
}
