using Microsoft.AspNetCore.Mvc;
using PracCrudMvcCore.Models;

namespace PracCrudMvcCore.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FetchAllData()
        {
            List<Student> alldata;
            using (PracticeContext context = new PracticeContext())
            {
                alldata = context.Students.ToList();
            }
            return Json(alldata);
        }

        public IActionResult AddData(Student s)
        {
            bool flag = false;
            using (var context = new PracticeContext())
            {
                var newStudent = new Student
                {
                    Name = s.Name,
                    Email = s.Email,
                    Salaryamt = s.Salaryamt
                };
                context.Students.Add(newStudent);
                context.SaveChanges();
                flag = true;
            }
            return Json(flag);
        }

        public IActionResult UpdateData(Student s)
        {
            bool flag = false;
            using (var context = new PracticeContext())
            {
                var studentToUpdate = context.Students.FirstOrDefault(stu => stu.StudentId == s.StudentId);
                if (studentToUpdate != null)
                {
                    Console.WriteLine("Enter name, email, salary");
                    studentToUpdate.Name = s.Name;
                    studentToUpdate.Email = s.Email;
                    studentToUpdate.Salaryamt = s.Salaryamt;
                    context.SaveChanges();
                }
                else
                {
                }
            }
            return Json(flag);
        }

        public IActionResult DeleteData(int id)
        {
            bool flag = false;
            using (var context = new PracticeContext())
            {
                var studentToUpdate = context.Students.FirstOrDefault(s => s.StudentId == id);
                if (studentToUpdate != null)
                {
                    context.Students.Remove(studentToUpdate);
                    context.SaveChanges();
                    flag = true;
                }
                else
                {
                }
            }
            return Json(flag);
        }
    }
}
