using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    static class Distance
    {
        public static double CalculateDistanceBetween3DPoints(Point3D first, Point3D second)
        {
            double deltaX = first.X - second.X;
            double deltaY = first.Y - second.Y;
            double deltaZ = first.Z - second.Z;

            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2) + Math.Pow(deltaZ, 2));

            return distance;
        }
    }
}
