using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Triangle : Shape
    {
        public double Side
        {
            get
            {
                return base.width;
            }
            set
            {
                base.width = value;
            }
        }

        public double Height
        {
            get
            {
                return base.height;
            }
            set
            {
                base.height = value;
            }
        }

        public Triangle(double width, double height)
            : base(width, height)
        {

        }

        public override double CalculateSurface()
        {
            double surface = (this.Side * this.Height) / 2;
            return surface;
        }
    }
}
