using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataModel
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Program program = new Program();
            int id = 0;
            Console.WriteLine("Enter Log file name");

            do
            {
                Console.WriteLine("\n 1. Add Record");
                Console.WriteLine("\n 2. Display Record");
                Console.WriteLine("\n 3. Update Record");
                Console.WriteLine("\n 4. Delete Record");
                Console.WriteLine("\n 5. exit");

                id = int.Parse(Console.ReadLine());

                switch (id)
                {
                    case 1:
                        program.InsertData();
                        break;
                    case 2:
                        program.DisplayData();
                        break;
                    case 3:
                        program.UpdateData();
                        break;
                    case 4:
                        program.DeleteData();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice");
                        break;
                }

            } while (id != 5);


            Console.ReadLine();
        }

        public void InsertData()
        {
            Console.WriteLine("Enter name, email, salary");
            String name = Console.ReadLine();
            String email = Console.ReadLine();
            String salary = Console.ReadLine();   
            using (var context = new practiceEntities())
            {
                var newStudent = new student
                {
                    name = name, email = email, salary = salary
                };
                context.students.Add(newStudent);
                context.SaveChanges();
                Console.WriteLine("Student Added Successfully");
            }
        }
        public void UpdateData()
        {
            Console.WriteLine("Enter id");
            int id = int.Parse(Console.ReadLine());
            
            using (var context = new practiceEntities())
            {
                var studentToUpdate = context.students.FirstOrDefault(s => s.id == id);
                if(studentToUpdate != null)
                {
                    Console.WriteLine("Enter name, email, salary");
                    studentToUpdate.name = Console.ReadLine();
                    studentToUpdate.email = Console.ReadLine();
                    studentToUpdate.salary = Console.ReadLine();
                    Console.WriteLine("Student updated");
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
        }

        public void DisplayData()
        {
            using (var context = new practiceEntities())
            {
                var all = context.students.ToList();
                foreach (var student in all)
                {
                    Console.WriteLine(student.id + " " + student.name + " " + student.email + " " + student.salary);
                }
            }
        }

        public void DeleteData()
        {
            Console.WriteLine("Enter id");
            int id = int.Parse(Console.ReadLine());

            using (var context = new practiceEntities())
            {
                var studentToUpdate = context.students.FirstOrDefault(s => s.id == id);
                if (studentToUpdate != null)
                {
                    context.students.Remove(studentToUpdate);
                    Console.WriteLine("Student Deleted"); 
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }
        }

    }
}
