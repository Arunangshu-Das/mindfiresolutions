using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Reflect
    {
        public static void MakeCall()
        {
            Type mytype = typeof(Cloud);
            PropertyInfo[] properties = mytype.GetProperties();


            MethodInfo[] methods = mytype.GetMethods();
            foreach (var item in properties)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in methods)
            {
                Console.WriteLine(item);
            }

            Type dynamicType = typeof(Int64);
            object instance = Activator.CreateInstance(dynamicType);
            instance = 16;
            Console.WriteLine(instance);

            mytype = typeof(Gcloud);
            instance = Activator.CreateInstance(mytype);
            var property = mytype.GetField("welcome");
            var tt = property.GetValue(instance);
            //dynamicType = typeof(string);   
            //instance = Activator.CreateInstance(dynamicType);
            //object propertyvalue = property[0].va
            Console.WriteLine(tt);
            var test = 0;
        }
    }
}
