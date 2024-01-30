using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleCrudLayerWise.DAL;
using MultipleCrudLayerWise.models;


namespace MultipleCrudLayerWise.Business
{
    public class Service
    {
        Dal dataAccess=new Dal();

        public bool AddStudent(StudentVO vo)
        {
            return dataAccess.AddStudent(vo);
        }

        public List<StudentVO> DisplayAllStudents()
        {
            return dataAccess.DisplayAllStudents();
        }

        public StudentVO DisplayStudent(int studentId)
        {
            return dataAccess.DisplayStudent(studentId);
        }

        public bool UpdateStudent(StudentVO vo)
        {
            return dataAccess.UpdateStudent(vo);  
        }

        public bool AssignStudentToClass(int studentId, int classId)
        {
            return dataAccess.AssignStudentToClass(studentId, classId);
        }

        public List<StudentClassVo> DisplayAllStudentAssignToClass(int classId)
        {
            return dataAccess.DisplayAllStudentAssignToClass((int)classId);
        }

        public List<StudentClassVo> DisplayAllClassAssignToStudent(int studentId)
        {
            return dataAccess.DisplayAllClassAssignToStudent(studentId);    
        }

        public bool RemoveStudentToClass(int studentId, int classId)
        {
            return dataAccess.RemoveStudentToClass(studentId,(int)classId);
        }

        public bool AssignCourseToClass(int courseId, int classId)
        {
            return dataAccess.AssignCourseToClass(courseId,(int)classId);
        }

        public List<CourseClassVo> DisplayAllCourseAssignToClass(int classId)
        {
            return dataAccess.DisplayAllCourseAssignToClass((int)classId);
        }

        public List<CourseClassVo> DisplayAllClassAssignToCourse(int courseId)
        {
            return dataAccess.DisplayAllClassAssignToCourse((int)courseId);
        }

        public bool RemoveCourseToClass(int courseId, int classId)
        {
            return dataAccess.RemoveCourseToClass(courseId,classId);
        }

        public bool DeleteStudent(StudentVO vo)
        {
            return dataAccess.DeleteStudent(vo);
        }

        public bool AddClass(ClassVO vo)
        {
            return dataAccess.AddClass(vo);
        }

        public List<ClassVO> DisplayAllClasses()
        {
            return dataAccess.DisplayAllClasses();
        }

        public bool UpdateClass(ClassVO vo)
        {
            return dataAccess.UpdateClass(vo);
        }

        public bool DeleteClass(ClassVO vo)
        {
            return dataAccess.DeleteClass(vo);
        }

        public bool AddCourse(CourseVO vo)
        {
            return dataAccess.AddCourse(vo);
        }

        public List<CourseVO> DisplayAllCourses()
        {
            return dataAccess.DisplayAllCourses();
        }

        public bool UpdateCourse(CourseVO vo)
        {
            return dataAccess.UpdateCourse(vo); 
        }

        public bool DeleteCourse(CourseVO vo)
        {
            return dataAccess.DeleteCourse(vo);
        }
    }
}
