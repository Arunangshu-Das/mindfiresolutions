using PracCrudLayerMvcCore.DAL.Models;
using PracCrudLayerMvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracCrudLayerMvcCore.DAL
{
    public class DataAccess : IDataAccess
    {

        private readonly PracticeContext context;

        public DataAccess(PracticeContext context)
        {
            this.context = context;
        }

        public bool UpdateData(StudentModel s)
        {
            bool flag = false;
            var studentToUpdate = context.Students.FirstOrDefault(stu => stu.StudentId == s.StudentId);
            if (studentToUpdate != null)
            {
                studentToUpdate.Name = s.Name;
                studentToUpdate.Email = s.Email;
                studentToUpdate.Salaryamt = s.Salaryamt;
                context.SaveChanges();
                flag = true;
            }
            else
            {
            }
            return flag;
        }

        public bool DeleteData(StudentModel s)
        {
            bool flag = false;
            var studentToUpdate = context.Students.FirstOrDefault(stu => stu.StudentId == s.StudentId);
            if (studentToUpdate != null)
            {
                context.Students.Remove(studentToUpdate);
                context.SaveChanges();
                flag = true;
            }
            else
            {
            }
            return flag;
        }

        public bool AddData(StudentModel s)
        {
            bool flag = false;
            var newStudent = new Student
            {
                Name = s.Name,
                Email = s.Email,
                Salaryamt = s.Salaryamt
            };
            context.Students.Add(newStudent);
            context.SaveChanges();
            flag = true;
            return flag;
        }

        public List<StudentModel> ListData()
        {
            List<StudentModel> alldata = new List<StudentModel>(); ;
            List<Student> result;
            result = context.Students.ToList();
            if (result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    alldata.Add(new StudentModel { Name = result[i].Name, Email = result[i].Email, Salaryamt = result[i].Salaryamt, StudentId = result[i].StudentId });
                }
            }
            return alldata;
        }

        public string GettestData()
        {
            return DateTime.Now.ToString();
        }
    }
}
