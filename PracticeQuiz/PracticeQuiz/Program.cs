using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeQuiz
{
    class Program
    {
        static void Main()
        {
            // Taking a string 
            String str = "23,45,21|09,33,98,,36,89,-11,09,4,100.5|33,89";

            String[] spearator = { ",", "|" };

            // using the method 
            var sum = str.Split(spearator, StringSplitOptions.RemoveEmptyEntries).Select(s => double.Parse(s)).Distinct().OrderByDescending(r => r).Take(3).ToString();

            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}


