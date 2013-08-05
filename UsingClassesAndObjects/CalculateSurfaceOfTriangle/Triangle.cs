using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSurfaceOfTriangle
{
    public class Triangle
    {
        /// <summary>
        /// Calculate surface of triangle by given side and altitude.
        /// </summary>
        /// <param name="side"></param>
        /// <param name="altitude"></param>
        /// <returns></returns>
        public static double CalculateTriangleSurface(double side, double altitude)
        {
            double surface = (side * altitude) / 2;
            return surface;
        }

        /// <summary>
        /// Calculate surface of triangle by given 3 sides.
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <returns></returns>
        public static double CalculateTriangleSurface(double sideA, double sideB, double sideC)
        {
            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double surface = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
            return surface;
        }

        /// <summary>
        /// Calculate surface of triangle by given 2 sides and angle (in degree) between them.
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double CalculateTriangleSurface(double sideA, double sideB, int angle)
        {
            double surface = (sideA * sideB * Math.Sin(DegreeToRadian(angle))) / 2;
            return surface;
        }

        private static double DegreeToRadian(double angle)
        {
            return (Math.PI * angle) / 180;
        }
    }
}
