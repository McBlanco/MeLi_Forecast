using System;
using System.Collections.Generic;
using System.Text;

namespace MeLi_Forecast.Entities.SolarSystems.MeLi
{
    public class MeLiSolarSystem : SolarSystem
    {
        public Planet FerengiPlanet     {get;set;}
        public Planet BetasoidePlanet   {get;set;}
        public Planet VulcanoPlanet { get; set; }

        public MeLiSolarSystem() : base()
        {
            /* Configure the Sun */
            this.Core.Name = "Sun";
            this.Core.Diameter = 100;

            /* Configure the planets */
            this.FerengiPlanet = new Planet("Ferengi", 20, true, 1, 500);
            this.BetasoidePlanet = new Planet("Betasoide", 20, true, 3, 2000);
            this.VulcanoPlanet = new Planet("Vulcano", 20, false, 5, 1000);

            this.Planets.AddRange(new List<Planet>() { this.FerengiPlanet, this.BetasoidePlanet, this.VulcanoPlanet });
        }

        public bool AreAlignedWithTheSun(uint day)
        {
            Position ferengiPosition = this.FerengiPlanet.GetPosition(this.FerengiPlanet.GetAngle(day));
            Position betasoidePosition = this.BetasoidePlanet.GetPosition(this.BetasoidePlanet.GetAngle(day));
            Position vulcanoPosition = this.VulcanoPlanet.GetPosition(this.VulcanoPlanet.GetAngle(day));
            Position sunPosition = this.Core.GetPosition(0);

            double slope1 = Utils.GetSlope(ferengiPosition, betasoidePosition);
            double slope2 = Utils.GetSlope(vulcanoPosition, sunPosition);

            return slope1 == slope2;
        }

        public bool AreAlignedWithoutTheSun(uint day)
        {
            Position ferengiPosition = this.FerengiPlanet.GetPosition(this.FerengiPlanet.GetAngle(day));
            Position betasoidePosition = this.BetasoidePlanet.GetPosition(this.BetasoidePlanet.GetAngle(day));
            Position vulcanoPosition = this.VulcanoPlanet.GetPosition(this.VulcanoPlanet.GetAngle(day));
            Position sunPosition = this.Core.GetPosition(0);

            double slope1 = Utils.GetSlope(ferengiPosition, betasoidePosition);
            double slope2 = Utils.GetSlope(vulcanoPosition, ferengiPosition);
            double slope3 = Utils.GetSlope(vulcanoPosition, sunPosition);

            return slope1 == slope2 && slope1 != slope3;
        }

        public bool AreAlignedWithSunInside(uint day)
        {
            Position ferengiPosition = this.FerengiPlanet.GetPosition(this.FerengiPlanet.GetAngle(day));
            Position betasoidePosition = this.BetasoidePlanet.GetPosition(this.BetasoidePlanet.GetAngle(day));
            Position vulcanoPosition = this.VulcanoPlanet.GetPosition(this.VulcanoPlanet.GetAngle(day));

            double slideA = Utils.GetDistance(ferengiPosition, betasoidePosition);
            double slideB = Utils.GetDistance(betasoidePosition, vulcanoPosition);
            double slideC = Utils.GetDistance(vulcanoPosition, ferengiPosition);

            return true;
        }

        public bool IsSunIncenter(uint day)
        {
            Position ferengiPosition = this.FerengiPlanet.GetPosition(this.FerengiPlanet.GetAngle(day));
            Position betasoidePosition = this.BetasoidePlanet.GetPosition(this.BetasoidePlanet.GetAngle(day));
            Position vulcanoPosition = this.VulcanoPlanet.GetPosition(this.VulcanoPlanet.GetAngle(day));

            double slideA = Utils.GetDistance(ferengiPosition, betasoidePosition);
            double slideB = Utils.GetDistance(betasoidePosition, vulcanoPosition);
            double slideC = Utils.GetDistance(vulcanoPosition, ferengiPosition);

            Position incenter = Utils.GetTriangeIncenter(ferengiPosition, slideA, betasoidePosition, slideB, vulcanoPosition, slideC);
            return incenter.X == 0 && incenter.Y == 0;
        }

        public override string GetWeather(uint day)
        {
            return "Rain";
        }
    }
}
