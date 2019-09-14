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

        public override Position GetPosition(double angle)
        {
            Position result = new Position();

            /* Get slide C of a triangle between the sun-distance (slideA), the distance-newPosition (slideB) and newPsition-sun (slideC) of the planet */
            double slideA = this.Distance;
            double slideB = this.Distance;
            double slideC = Utils.GetTriangleSlideC(slideA, slideB, angle);

            double triangleHeight = Utils.GetIsoscelesTriangleHeight(slideA, angle);
            double triangleWidth = Utils.GetTriangleSlideC(slideA, triangleHeight, 180 - 90 - angle);

            result.X = triangleWidth;
            result.Y = triangleHeight;

            return result;
        }

        public double GetAngle(uint day)
        {
            double result;

            if (this.IsClockwise)
            {
                result = 360 - ((day * this.Traslation) % 360);
            }
            else
            {
                result = (day * this.Traslation) % 360;
            }

            return result;
        }
    }
}
