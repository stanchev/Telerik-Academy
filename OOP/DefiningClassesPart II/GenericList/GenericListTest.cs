using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericListTest
    {
        static void Main(string[] args)
        {
            GenericList<int> l = new GenericList<int>(5);
            l.AddElement(10);
            l.AddElement(20);
            l.AddElement(30);
            l.AddElement(40);
            l.AddElement(50);
            l.InsertElementAt(0, 60);
            l.RemoveElementAt(0);
            l.AddElement(60);
            l.AddElement(70);
            l.AddElement(0);
            Console.WriteLine(l.Count);
            Console.WriteLine("Min: {0}", l.Min());
            Console.WriteLine("Max: {0}", l.Max());
        }
    }
}
