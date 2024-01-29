using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleCrudLayerWise.DAL;

namespace MultipleCrudLayerWise.Business
{
    public class Service
    {
        Dal dataAccess=new Dal();

        public bool AddStudent(string name, string fileName)
        {
            return dataAccess.AddStudent(name, fileName);
        }

        public void DisplayAllStudents(string fileName)
        {
            dataAccess.DisplayAllStudents(fileName);
        }

        public bool DisplayStudent(int studentId, string fileName)
        {
            return dataAccess.DisplayStudent(studentId, fileName);
        }

        public bool UpdateStudent(int studentId, string newName, string fileName)
        {
            return dataAccess.UpdateStudent(studentId, newName, fileName);  
        }

        public bool AssignStudentToClass(int studentId, int classId, string fileName)
        {
            return dataAccess.AssignStudentToClass(studentId, classId, fileName);
        }

        public bool DisplayAllStudentAssignToClass(int classId, string fileName)
        {
            return dataAccess.DisplayAllStudentAssignToClass((int)classId, fileName);
        }

        public bool DisplayAllClassAssignToStudent(int studentId, string fileName)
        {
            return dataAccess.DisplayAllClassAssignToStudent(studentId,fileName);    
        }

        public bool RemoveStudentToClass(int studentId, int classId, string fileName)
        {
            return dataAccess.RemoveStudentToClass(studentId,(int)classId,fileName);
        }

        public bool AssignCourseToClass(int courseId, int classId, string fileName)
        {
            return dataAccess.AssignCourseToClass(courseId,(int)classId,fileName);
        }

        public bool DisplayAllCourseAssignToClass(int classId, string fileName)
        {
            return dataAccess.DisplayAllCourseAssignToClass((int)classId,fileName);
        }

        public bool DisplayAllClassAssignToCourse(int courseId, string fileName)
        {
            return dataAccess.DisplayAllClassAssignToCourse((int)courseId,fileName);
        }

        public bool RemoveCourseToClass(int courseId, int classId, string fileName)
        {
            return dataAccess.RemoveCourseToClass(courseId,classId,fileName);
        }

        public bool DeleteStudent(int studentId, string fileName)
        {
            return dataAccess.DeleteStudent(studentId, fileName);
        }

        public bool AddClass(string className, string fileName)
        {
            return dataAccess.AddClass(className, fileName);
        }

        public bool DisplayAllClasses(string fileName)
        {
            return dataAccess.DisplayAllClasses(fileName);
        }

        public bool UpdateClass(int classId, string newClassName, string fileName)
        {
            return dataAccess.UpdateClass(classId, newClassName,fileName);
        }

        public bool DeleteClass(int classId, string fileName)
        {
            return dataAccess.DeleteClass(classId,fileName);
        }

        public bool AddCourse(string courseName, string fileName)
        {
            return dataAccess.AddCourse(courseName, fileName);
        }

        public bool DisplayAllCourses(string fileName)
        {
            return dataAccess.DisplayAllCourses(fileName);
        }

        public bool UpdateCourse(int courseId, string fileName)
        {
            return dataAccess.UpdateCourse(courseId,fileName); 
        }

        public bool DeleteCourse(int courseId, string fileName)
        {
            return dataAccess.DeleteCourse(courseId, fileName);
        }
    }
}
