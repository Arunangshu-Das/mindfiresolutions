using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1,2,3,4,5,6,7,8,9,10,98,34,65,28,24,25,28,45,48,58,82,42,52};
            var evenno=from num in numbers
                       where num%2==0
                       select num;
            var evenNo2 = numbers.Where(r => r % 2 == 0).ToList();

            foreach (var i in evenno)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
