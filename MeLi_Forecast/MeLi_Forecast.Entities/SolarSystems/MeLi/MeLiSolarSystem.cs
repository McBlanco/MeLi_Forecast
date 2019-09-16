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

            /* Configure the planets */
            this.FerengiPlanet = new Planet("Ferengi", true, 1, 500);
            this.BetasoidePlanet = new Planet("Betasoide", true, 3, 2000);
            this.VulcanoPlanet = new Planet("Vulcano", false, 5, 1000);

            this.Planets.AddRange(new List<Planet>() { this.FerengiPlanet, this.BetasoidePlanet, this.VulcanoPlanet });
        }

        public bool AreAlignedWithTheSun(uint day)
        {
            Position ferengiPosition_start = this.FerengiPlanet.GetPosition(day);
            Position betasoidePosition_start = this.BetasoidePlanet.GetPosition(day);
            Position vulcanoPosition_start = this.VulcanoPlanet.GetPosition(day);
            Position ferengiPosition_end = this.FerengiPlanet.GetPosition(day + 0.999999);
            Position betasoidePosition_end = this.BetasoidePlanet.GetPosition(day + 0.999999);
            Position vulcanoPosition_end = this.VulcanoPlanet.GetPosition(day + 0.999999);
            Position sunPosition = this.Core.GetPosition(day);

            double ferengi_betasoide_slope_start = Utils.GetSlope(ferengiPosition_start, betasoidePosition_start);
            double ferengi_vulcano_slope_start = Utils.GetSlope(ferengiPosition_start, vulcanoPosition_start);
            double vulcano_sun_slope_start = Utils.GetSlope(vulcanoPosition_start, sunPosition);
            double ferengi_betasoide_slope_end = Utils.GetSlope(ferengiPosition_end, betasoidePosition_end);
            double ferengi_vulcano_slope_end = Utils.GetSlope(ferengiPosition_end, vulcanoPosition_end);
            double vulcano_sun_slope_end = Utils.GetSlope(vulcanoPosition_end, sunPosition);

            bool arePlanetsAlignedWithTheSun = ((ferengi_betasoide_slope_start >= ferengi_vulcano_slope_start &&
                                        ferengi_betasoide_slope_end <= ferengi_vulcano_slope_end) ||
                                        (ferengi_betasoide_slope_start <= ferengi_vulcano_slope_start &&
                                        ferengi_betasoide_slope_end >= ferengi_vulcano_slope_end))
                                        &&
                                    ((ferengi_betasoide_slope_start >= vulcano_sun_slope_start &&
                                        ferengi_betasoide_slope_end <= vulcano_sun_slope_end) ||
                                        (ferengi_betasoide_slope_start <= vulcano_sun_slope_start &&
                                        ferengi_betasoide_slope_end >= vulcano_sun_slope_end))
                                        &&
                                    ((ferengi_vulcano_slope_start >= vulcano_sun_slope_start &&
                                        ferengi_vulcano_slope_end <= vulcano_sun_slope_end) ||
                                        (ferengi_vulcano_slope_start <= vulcano_sun_slope_start &&
                                        ferengi_vulcano_slope_end >= vulcano_sun_slope_end));

            return arePlanetsAlignedWithTheSun;
        }

        public bool AreAlignedWithoutTheSun(uint day)
        {
            Position ferengiPosition_start = this.FerengiPlanet.GetPosition(day);
            Position betasoidePosition_start = this.BetasoidePlanet.GetPosition(day);
            Position vulcanoPosition_start = this.VulcanoPlanet.GetPosition(day);
            Position ferengiPosition_end = this.FerengiPlanet.GetPosition(day + 1);
            Position betasoidePosition_end = this.BetasoidePlanet.GetPosition(day + 1);
            Position vulcanoPosition_end = this.VulcanoPlanet.GetPosition(day + 1);

            double ferengi_betasoide_slope_start = Utils.GetSlope(ferengiPosition_start, betasoidePosition_start);
            double ferengi_vulcano_slope_start = Utils.GetSlope(ferengiPosition_start, vulcanoPosition_start);
            double betasoide_vulcano_slope_start = Utils.GetSlope(betasoidePosition_start, vulcanoPosition_start);
            double ferengi_betasoide_slope_end = Utils.GetSlope(ferengiPosition_end, betasoidePosition_end);
            double ferengi_vulcano_slope_end = Utils.GetSlope(ferengiPosition_end, vulcanoPosition_end);
            double betasoide_vulcano_slope_end = Utils.GetSlope(betasoidePosition_end, vulcanoPosition_end);

            bool arePlanetsAligned = ((ferengi_betasoide_slope_start > ferengi_vulcano_slope_start &&
                                        ferengi_betasoide_slope_end < ferengi_vulcano_slope_end) ||
                                        (ferengi_betasoide_slope_start < ferengi_vulcano_slope_start &&
                                        ferengi_betasoide_slope_end > ferengi_vulcano_slope_end))
                                        &&
                                    ((ferengi_betasoide_slope_start > betasoide_vulcano_slope_start &&
                                        ferengi_betasoide_slope_end < betasoide_vulcano_slope_end) ||
                                        (ferengi_betasoide_slope_start < betasoide_vulcano_slope_start &&
                                        ferengi_betasoide_slope_end > betasoide_vulcano_slope_end))
                                        &&
                                    ((ferengi_vulcano_slope_start > betasoide_vulcano_slope_start &&
                                        ferengi_vulcano_slope_end < betasoide_vulcano_slope_end) ||
                                        (ferengi_vulcano_slope_start < betasoide_vulcano_slope_start &&
                                        ferengi_vulcano_slope_end > betasoide_vulcano_slope_end));

            return arePlanetsAligned;
        }

        public bool IsSunInside(uint day)
        {
            if (this.AreAlignedWithTheSun(day))
                return false;

            Position ferengiPosition = this.FerengiPlanet.GetPosition(day);
            Position betasoidePosition = this.BetasoidePlanet.GetPosition(day);
            Position vulcanoPosition = this.VulcanoPlanet.GetPosition(day);
            Position corePosition = this.Core.GetPosition(day);

            return Utils.PointInTriangle(corePosition, ferengiPosition, betasoidePosition, vulcanoPosition);
        }

        public bool IsMaxPerimeter(uint day)
        {
            Position ferengiPosition_before = this.FerengiPlanet.GetPosition(day - 1);
            Position betasoidePosition_before = this.BetasoidePlanet.GetPosition(day - 1);
            Position vulcanoPosition_before = this.VulcanoPlanet.GetPosition(day - 1);
            Position ferengiPosition_start = this.FerengiPlanet.GetPosition(day);
            Position betasoidePosition_start = this.BetasoidePlanet.GetPosition(day);
            Position vulcanoPosition_start = this.VulcanoPlanet.GetPosition(day);
            Position ferengiPosition_end = this.FerengiPlanet.GetPosition(day + 1);
            Position betasoidePosition_end = this.BetasoidePlanet.GetPosition(day + 1);
            Position vulcanoPosition_end = this.VulcanoPlanet.GetPosition(day + 1);

            double perimeter_start = Utils.GetTrianglePerimeter(ferengiPosition_start, betasoidePosition_start, vulcanoPosition_start);
            double perimeter_end = Utils.GetTrianglePerimeter(ferengiPosition_end, betasoidePosition_end, vulcanoPosition_end);
            double perimeter_before = Utils.GetTrianglePerimeter(ferengiPosition_before, betasoidePosition_before, vulcanoPosition_before);

            return perimeter_start > perimeter_before && perimeter_start > perimeter_end;
        }

        public double GetTrianglePerimeter(uint day)
        {
            Position ferengiPosition = this.FerengiPlanet.GetPosition(day);
            Position betasoidePosition = this.BetasoidePlanet.GetPosition(day);
            Position vulcanoPosition = this.VulcanoPlanet.GetPosition(day);

            return Utils.GetTrianglePerimeter(ferengiPosition, betasoidePosition, vulcanoPosition);
        }

        public override string GetWeather(uint day)
        {
            string result = "none";

            if (this.AreAlignedWithTheSun(day))
                result = "drought";
            else if (this.AreAlignedWithoutTheSun(day))
                result = "optimum pressure and temperature";
            else if (this.IsSunInside(day) && this.IsMaxPerimeter(day))
                result = "lot of rain";
            else if (this.IsSunInside(day))
                result = "rainy";
            else
                result = "tempered";

            return result;
        }
    }
}
