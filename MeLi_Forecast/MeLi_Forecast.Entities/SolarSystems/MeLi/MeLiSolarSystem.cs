using System;
using System.Collections.Generic;
using System.Text;

namespace MeLi_Forecast.Entities.SolarSystems.MeLi
{
    public class MeLiSolarSystem : SolarSystem
    {
        public MeLiSolarSystem() : base()
        {
            /* Configure the Sun */
            this.Core.Name = "Sun";
            this.Core.Diameter = 100;

            /* Configure the planets */
            this.Planets.Add(new Planet("Ferengi", 20, true, 1, 500));
            this.Planets.Add(new Planet("Betasoide", 20, true, 3, 2000));
            this.Planets.Add(new Planet("Vulcano", 20, false, 5, 1000));
        }

        public override string GetWeather(uint day)
        {
            return "Rain";
        }
    }
}
