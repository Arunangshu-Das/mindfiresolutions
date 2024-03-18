// See https://aka.ms/new-console-template for more information
using ConsoleApp1.Models;

int ch = 0;
int id = 0;
do
{
    Console.WriteLine("\n 1. Add Record");
    Console.WriteLine("\n 2. Display Record");
    Console.WriteLine("\n 3. Update Record");
    Console.WriteLine("\n 4. Delete Record");
    Console.WriteLine("\n 5. exit");

    ch = int.Parse(Console.ReadLine());

    switch (ch)
    {
        case 1:
            Console.WriteLine("Enter Name");
            string name= Console.ReadLine();
            Console.WriteLine("Enter Email");
            string email= Console.ReadLine();
            Console.WriteLine("Enter Salary");
            int salary=Convert.ToInt32(Console.ReadLine());
            InsertRecord(name, email,salary);
            break;
        case 2:
            DisplayData();
            break;
        case 3:
            Console.WriteLine("Enter ID");
            id = Convert.ToInt32(Console.ReadLine());
            UpdateRecord(id);
            break;
        case 4:
            Console.WriteLine("Enter ID");
            id = Convert.ToInt32(Console.ReadLine());
            DeleteRecord(id);
            break;
        case 5:
            break;
        default:
            Console.WriteLine("Enter a valid choice");
            break;
    }

} while (ch != 5);

void InsertRecord(String name, String email, int salary)
{
    using (var context = new PracticeContext())
    {
        var newStudent = new Student
        {
            Name = name,
            Email = email,
            Salaryamt = salary
        };
        context.Students.Add(newStudent);
        context.SaveChanges();
        Console.WriteLine("Student Added Successfully");
    }
}

void DisplayData()
{
    using (var context = new PracticeContext())
    {
        var all = context.Students.ToList();
        foreach (var student in all)
        {
            Console.WriteLine(student.StudentId + " " + student.Name + " " + student.Email + " " + student.Salaryamt);
        }
    }
}

void UpdateRecord(int id)
{
    using (var context = new PracticeContext())
    {
        var studentToUpdate = context.Students.FirstOrDefault(s => s.StudentId == id);
        if (studentToUpdate != null)
        {
            Console.WriteLine("Enter name, email, salary");
            studentToUpdate.Name = Console.ReadLine();
            studentToUpdate.Email = Console.ReadLine();
            studentToUpdate.Salaryamt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Student updated");
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }
}

void DeleteRecord(int id)
{
    using (var context = new PracticeContext())
    {
        var studentToUpdate = context.Students.FirstOrDefault(s => s.StudentId == id);
        if (studentToUpdate != null)
        {
            context.Students.Remove(studentToUpdate);
            Console.WriteLine("Student Deleted");
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Not Found");
        }
    }
}