using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Point
{
    static class PathStorage
    {
        private const string INPUT_FILE = @"input.txt";
        private const string OUTPUT_FILE = @"output.txt";

        public static List<Path> paths = new List<Path>();

        public static void LoadPath()
        {
            using (TextReader read = new StreamReader(INPUT_FILE))
            {
                string line = null;
                int pointCount = 0;
                while ((line = read.ReadLine()) != null)
                {
                    string[] point3D = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    paths.Add(new Path());
                    for (int i = 0; i < point3D.Length; i++)
                    {
                        string[] pointCoordinates = point3D[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        paths[pointCount].AddPoint(new Point3D(int.Parse(pointCoordinates[0]),
                            int.Parse(pointCoordinates[1]), int.Parse(pointCoordinates[2])));
                    }
                    pointCount++;
                }
            }
        }

        public static void SavePath()
        {
            using (TextWriter write = new StreamWriter(OUTPUT_FILE))
            {
                foreach (Path path in paths)
                {
                    for (int i = 0; i < path.GetPoints.Length - 1; i++)
                    {
                        Point3D point = path.GetPoints[i];
                        write.Write(point.X + "," + point.Y + "," + point.Z + ";");
                    }
                    Point3D lastPoint = path.GetPoints[path.GetPoints.Length - 1];
                    write.Write(lastPoint.X + "," + lastPoint.Y + "," + lastPoint.Z + Environment.NewLine);
                }
            }
            paths.Clear();
        }

        public static void PrintPaths()
        {
            if (paths.Count == 0)
            {
                Console.WriteLine("Empty list of paths.");
            }
            else
            {
                for (int i = 0; i < paths.Count; i++)
                {
                    Console.WriteLine("Points of path #{0}: ", (i + 1));
                    for (int j = 0; j < paths[i].GetPoints.Length; j++)
                    {
                        Console.WriteLine("Coordinates of point #{0}: {1}", (j + 1), paths[i].GetPoints[j]);
                    }
                    Console.WriteLine(new string('-', 25));
                }
            }
        }
    }
}
