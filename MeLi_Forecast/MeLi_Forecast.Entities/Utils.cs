using MeLi_Forecast.Entities.SolarSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeLi_Forecast.Entities
{
    public static class Utils
    {
        /// <summary>
        /// Calculate the slide C of a triangle knowing the slides A and B and the angle between both
        /// </summary>
        /// <param name="slideA"></param>
        /// <param name="slideB"></param>
        public static double GetTriangleSlideC(double slideA, double slideB, double angleAB)
        {
            /* Aplying the cosine theorem --> c^2 = a^2 + b^2 - 2ab * cos(gamma) */
            double squareRootSlideA = Math.Pow(slideA, 2);
            double cosinAngleAB = Math.Cos(Utils.DegreeToRadian(angleAB));
            double result = squareRootSlideA + Math.Pow(slideB, 2) - 2 * slideA * slideB * cosinAngleAB;

            /* c = (result) ^ (1/2) */
            double squareRootResult = Math.Sqrt(result);
            return squareRootResult;
        }

        /// <summary>
        /// Get the height of a isosceles triangle
        /// </summary>
        /// <param name="slideA"></param>
        /// <param name="slideB"></param>
        /// <param name="slideC"></param>
        /// <returns></returns>
        public static double GetIsoscelesTriangleHeight(double sideBase, double angle)
        {
            //double semiPerimeter = (2 * equalSide + unequalSide) / 2;
            //double height = Math.Sqrt(Math.Pow(equalSide, 2) - (Math.Pow(unequalSide, 2) / 4));
            double height = sideBase * Math.Sin(Utils.DegreeToRadian(angle));
            return height;
        }

        public static Position GetTriangeIncenter(Position positionA, double slideA, Position positionB, double slideB, Position positionC, double slideC)
        {
            Position result = new Position();

            double perimeter = slideA + slideB + slideC;

            result.X = (positionA.X * slideA + positionB.X * slideB + positionC.X * slideC) / perimeter;
            result.Y = (positionA.Y * slideA + positionB.Y * slideB + positionC.Y * slideC) / perimeter;

            return result;
        }

        public static double GetDistance(Position b, Position a)
        {
            double result = Math.Sqrt( Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
            return result;
        }

        public static double GetSlope(Position b, Position a)
        {
            return (b.Y - a.Y) / (b.X - a.X);
        }

        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
