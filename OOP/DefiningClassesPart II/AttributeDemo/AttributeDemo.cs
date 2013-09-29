using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    [Version(1,2)]
    class AttributeDemo
    {
        [Version(10, 12)]
        public void Test()
        {
        }

        [Version(10, 11)]
        private void Test1()
        {
        }

        [Version(10,12)]
        static void Main(string[] args)
        {
            MemberInfo member = typeof(AttributeDemo);
            
            Console.WriteLine("Information for class: {0}",member.Name);
            foreach (Attribute attribute in member.GetCustomAttributes())
            {
                if (attribute is VersionAttribute)
                {
                    VersionAttribute version = (VersionAttribute)attribute;
                    Console.WriteLine("     Version: {0}",version.GetVersion);
                }
            }
            foreach (MethodInfo method in typeof(AttributeDemo).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                Console.WriteLine("Method name : {0}",method.Name);
                foreach (Attribute attribute in method.GetCustomAttributes())
                {
                    if (attribute is VersionAttribute)    
                    {
                        VersionAttribute version = (VersionAttribute)attribute;
                        Console.WriteLine("     Version: {0}", version.GetVersion);
                    }
                }
            }
        }
    }
}
