using System;
using System.Collections.Generic;
using System.Text;

namespace MeLi_Forecast.Entities.SolarSystems
{
    public abstract class SolarSystem
    {
        public CelestialObject Core { get; set; }
        public List<Planet> Planets { get; set; }

        public SolarSystem()
        {
            this.Core = new CelestialObject();
            this.Planets = new List<Planet>();
        }

        public abstract string GetWeather(uint day);
    }
}
