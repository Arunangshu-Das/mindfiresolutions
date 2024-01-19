using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "file.txt";
            do
            {
                Console.WriteLine("Enter data to add file");
                string inputData = Console.ReadLine();
                using (StreamWriter writer = new StreamWriter(file,true))
                {
                    writer.WriteLine(inputData);
                }
                Console.WriteLine("Do you want to add more data y/n");
                string choice=Console.ReadLine().ToLower();
                if(choice == "n" || choice == "no")
                {

                    if (File.Exists(file))
                    {
                        Console.WriteLine();
                        string[] lines = File.ReadAllLines(file);

                        foreach (string ln in lines)
                            Console.WriteLine(ln);
                        Console.WriteLine();
                    }

                    Console.WriteLine("Do you want to add more data y/n");
                    choice = Console.ReadLine().ToLower();
                    if(choice == "n" || choice == "no")
                    {
                        break;
                    }
                }
            }
            while (true);
        }
    }
}
