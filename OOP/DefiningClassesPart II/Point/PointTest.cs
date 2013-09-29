using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    public class PointTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Point3D.Point0);
            double d = Distance.CalculateDistanceBetween3DPoints(Point3D.Point0, new Point3D(1, 3, 5.23));
            Console.WriteLine(d);
            Path p = new Path();
            PathStorage.LoadPath();
            PathStorage.PrintPaths();
            PathStorage.SavePath();
            PathStorage.PrintPaths();
        }
    }
}
