using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRepresentationOfFloat
{
    class Program
    {
        /// <summary>
        /// Get binary representation of float.
        /// </summary>
        /// <param name="number"></param>
        static void GetBinaryRepresentationOfFloat(float number)
        {
            int mask = 1;
            int intRepresentation = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
            StringBuilder s = new StringBuilder();
            Console.Write("Mantisa : ");
            for (int i = 0; i <= 22; i++)
            {
                byte bit = (byte)(intRepresentation & mask);
                s.Insert(0, bit.ToString());
                intRepresentation = intRepresentation >> 1;
            }
            Console.Write(s.ToString());
            s.Clear();
            Console.Write("\nEksponenta : ");
            for (int i = 23; i <= 30; i++)
            {
                byte bit = (byte)(intRepresentation & mask);
                s.Insert(0, bit.ToString());
                intRepresentation = intRepresentation >> 1;
            }
            Console.Write(s.ToString());
            s.Clear();
            Console.Write("\nSign : ");
            Console.Write("{0}", (byte)(intRepresentation & mask));
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            GetBinaryRepresentationOfFloat(-27.25f);
        }
    }
}
