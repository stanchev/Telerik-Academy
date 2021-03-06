﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Rectangle : Shape
    {
        public double Width
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

        public Rectangle(double width, double height)
            : base(width, height)
        {

        }
        
        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
