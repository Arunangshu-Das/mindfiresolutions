using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRUDOperation.DAO;
using System.Threading.Tasks;
using System.IO;

namespace CRUDOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Student student = new Student();
            int id = 0;
            Console.WriteLine("Enter Log file name");
            String fileName = Console.ReadLine()+".txt";
            student.CreateTable(fileName);

            do
            {
                Console.WriteLine("\n 1. Add Record");
                Console.WriteLine("\n 2. Display Record");
                Console.WriteLine("\n 3. Delete Record");
                Console.WriteLine("\n 4. exit");

                id=int.Parse(Console.ReadLine());

                switch (id)
                {
                    case 1: 
                        program.insertRecord(fileName);
                        break;
                    case 2:
                        student.DisplayData(fileName);
                        break;
                    case 3:
                        program.DeleteRecord(fileName);
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice");
                        break;
                }

            } while (id!=4);


            Console.ReadLine();
        }

        /// <summary>
        /// Insert record call in DAO
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Status in String</returns>
        public String insertRecord(String fileName)
        {
            Console.WriteLine("Enter name, email, salary to add file");
            string name = Console.ReadLine();
            string email = Console.ReadLine();
            string salary = Console.ReadLine();
            Student i = new Student();
            i.InsertRecord(name, email, salary, fileName);
            return "success";
        }

        /// <summary>
        /// Delete Record call in DAO
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Status in String</returns>
        public String DeleteRecord(String fileName)
        {
            Console.WriteLine("Enter id");
            int id = int.Parse(Console.ReadLine());
            Student delete = new Student();
            delete.DeleteData(id, fileName);
            return "success";
        }

    }
}
