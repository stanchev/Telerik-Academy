using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    abstract class Shape
    {
        protected double width;
        protected double height;

        protected Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        abstract public double CalculateSurface();
    }
}
