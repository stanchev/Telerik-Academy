using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    class Path
    {
        private List<Point3D> points;

        public Point3D[] GetPoints
        {
            get
            {
                return this.points.ToArray();
            }
        }

        public Path()
            : this(new List<Point3D>())
        {

        }

        public Path(IEnumerable<Point3D> points)
        {
            this.points = new List<Point3D>(points);
        }

        public void AddPoint(Point3D point)
        {
            this.points.Add(point);
        }
    }
}
