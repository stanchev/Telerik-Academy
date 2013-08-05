using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSurfaceOfTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Surface of triangle by side and altitude : {0:.000}",
                Triangle.CalculateTriangleSurface(14, 10));
            Console.WriteLine("Surface of triangle by 3 side and altitude : {0:.000}",
                Triangle.CalculateTriangleSurface(8.0, 9.0, 11.0));
            Console.WriteLine("Surface of triangle by 2 sides and angle (in degree) between them : {0:.000}",
                Triangle.CalculateTriangleSurface(5.0, 7.0, 45));
        }
    }
}
