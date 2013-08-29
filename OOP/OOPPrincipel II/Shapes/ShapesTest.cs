/*Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height. Define two
 * new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure 
 * (height*width for rectangle and height*width/2 for triangle). Define class Circle and suitable constructor so that at
 * initialization height must be kept equal to width and implement the CalculateSurface() method. Write a program that 
 * tests the behavior of the CalculateSurface() method for different shapes (Circle, Rectangle, Triangle) stored in an 
 * array.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class ShapesTest
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Triangle(10, 3));
            shapes.Add(new Rectangle(10, 3));
            shapes.Add(new Circle(10));

            foreach (Shape item in shapes)
            {
                Console.WriteLine("{0} area is: {1}", item.GetType().Name, item.CalculateSurface());
            }
        }
    }
}
