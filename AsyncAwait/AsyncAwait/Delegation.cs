using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{

    public delegate void MyDelegate(String msg);

    public class Delegation
    {
        public static void Run()
        {
            MyDelegate mydelegate= new MyDelegate(PrintMessage);
            mydelegate("Hello !!");

            Console.WriteLine(mydelegate.ToString());

            mydelegate.Invoke("Invoking using method");
        }
        static void PrintMessage(String msg)
        {
            foreach (var item in msg.Split(' '))
            {
                Console.WriteLine(item);
            };
        }
    }
}
