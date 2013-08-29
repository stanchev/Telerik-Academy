using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Circle : Shape
    {
        public double Radius
        {
            get
            {
                return base.width;
            }
            set
            {
                base.width = base.height = value;
            }
        }

        public Circle(double radius)
            : base(radius, radius)
        {

        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * Math.Pow(this.Radius, 2);
            return surface;
        }
    }
}
