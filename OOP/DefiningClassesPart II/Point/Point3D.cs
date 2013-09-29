using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    struct Point3D
    {
        private static readonly Point3D point0 = new Point3D(0, 0, 0);

        private double x;
        private double y;
        private double z;

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Point3D Point0
        {
            get
            {
                return point0;
            }
        }

        public override string ToString()
        {
            string pointInfo = string.Format("(x = {0}, y = {1}, z = {2})", this.x, this.y, this.z);
            return pointInfo;
        }
    }
}
