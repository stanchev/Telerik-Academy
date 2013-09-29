using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class MatrixTest
    {
        static void Main(string[] args)
        {
            Matrix<int> m = new Matrix<int>(3, 3);
            Matrix<int> m1 = new Matrix<int>(3, 4);

            m[0, 0] = 3; m[0, 1] = 4; m[0, 2] = 6;
            m[1, 0] = -1; m[1, 1] = 2; m[1, 2] = 3;
            m[2, 0] = 10; m[2, 1] = 10; m[2, 2] = 2;

            m1[0, 0] = 2; m1[0, 1] = 3; m1[0, 2] = 5; m1[0, 3] = 6;
            m1[1, 0] = 1; m1[1, 1] = 2; m1[1, 2] = 3; m1[1, 3] = 1;
            m1[2, 0] = 2; m1[2, 1] = 4; m1[2, 2] = 8; m1[2, 3] = 7;

            Matrix<int> m2 = m * m1;
            if (m)
            {
                Console.WriteLine("true");
            }
            Console.WriteLine();
        }
    }
}
