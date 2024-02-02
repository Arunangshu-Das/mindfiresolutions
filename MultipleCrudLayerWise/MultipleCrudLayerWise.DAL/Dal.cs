using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleCrudLayerWise.Utils;
using MultipleCrudLayerWise.models;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;

namespace MultipleCrudLayerWise.DAL
{
    public class Dal
    {
        public bool AddStudent(StudentVO vo)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {

                    Student newStudent = new Student
                    {
                        Name = vo.Name
                    };

                    dbContext.Students.Add(newStudent);
                    dbContext.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return flag;
        }

        public List<StudentVO> DisplayAllStudents()
        {
            List < StudentVO > allStudentsVo = null;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                   List<Student> allStudents = dbContext.Students.ToList();

                    allStudentsVo=new List<StudentVO>();
                    foreach (var student in allStudents)
                    {
                        StudentVO vo = new StudentVO
                        {
                            Name = student.Name,
                            StudentID = student.StudentID
                        };
                        allStudentsVo.Add(vo);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return allStudentsVo;
        }

        public StudentVO DisplayStudent(int studentId)
        {
            StudentVO found = null;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Student foundStudent = dbContext.Students.Find(studentId);

                    if (foundStudent != null)
                    {
                        found = new StudentVO();
                        found.StudentID = foundStudent.StudentID;
                        found.Name = foundStudent.Name;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return found;
        }

        public bool UpdateStudent(StudentVO vo)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Student studentToUpdate = dbContext.Students.Find(vo.StudentID);

                    if (studentToUpdate != null)
                    {
                        studentToUpdate.Name = vo.Name;
                        dbContext.SaveChanges();

                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public bool AssignStudentToClass(int studentId, int classId)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Student student = dbContext.Students.Find(studentId);
                    Class classObj = dbContext.Classes.Find(classId);

                    if (student != null && classObj != null)
                    {
                        //classObj.Students.Add(student);

                        StudentClass studentClass = new StudentClass
                        {
                            StudentID = studentId,
                            ClassID = classId,
                        };
                        dbContext.StudentClasses.Add(studentClass);
                        dbContext.SaveChanges();

                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public List<StudentClassVo> DisplayAllStudentAssignToClass(int classId)
        {
            List<StudentClassVo> listvo = null;
            StudentClassVo vo = null;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Class classname = dbContext.Classes.Find(classId);
                    List<StudentClass> allStudents = dbContext.StudentClasses.Where(e => e.ClassID == classId).ToList();

                    if (allStudents.Count > 0)
                    {
                        listvo=new List<StudentClassVo>();
                        foreach (var item in allStudents)
                        {
                            Student classObj = dbContext.Students.Find(item.StudentID);
                            vo = new StudentClassVo();
                            vo.studentname=classObj.Name;
                            vo.classname=classname.ClassName;
                            listvo.Add(vo);
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return listvo;
        }

        public List<StudentClassVo> DisplayAllClassAssignToStudent(int studentId)
        {
            List<StudentClassVo> listvo = null;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Student studentname = dbContext.Students.Find(studentId);
                    List<StudentClass> allClasses = dbContext.StudentClasses.Where(e => e.StudentID == studentId).ToList();
                    listvo = new List<StudentClassVo>();
                    if (allClasses.Count > 0)
                    {
                        foreach (var item in allClasses)
                        {
                            Class classObj = dbContext.Classes.Find(item.ClassID);
                            StudentClassVo vo = new StudentClassVo
                            {
                                classname = classObj.ClassName,
                                studentname = studentname.Name
                            };
                            listvo.Add(vo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return listvo.OrderBy(s=>s.classname).ToList();
        }

        public bool RemoveStudentToClass(int studentId, int classId)
        {
            bool flag = false;  
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    var recordToDelete = dbContext.StudentClasses.FirstOrDefault(e => e.StudentID == studentId && e.ClassID == classId);

                    if (recordToDelete != null)
                    {
                        dbContext.StudentClasses.Remove(recordToDelete);
                        dbContext.SaveChanges();
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public bool AssignCourseToClass(int courseId, int classId)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Course course = dbContext.Courses.Find(courseId);
                    Class classObj = dbContext.Classes.Find(classId);

                    if (course != null && classObj != null)
                    {
                        //classObj.courses.Add(course);

                        CourseClass courseClass = new CourseClass
                        {
                            CourseID = courseId,
                            ClassID = classId,
                        };
                        dbContext.CourseClasses.Add(courseClass);
                        dbContext.SaveChanges();

                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public List<CourseClassVo> DisplayAllCourseAssignToClass(int classId)
        {
            List<CourseClassVo> courseClass = null;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Class classname = dbContext.Classes.Find(classId);
                    List<CourseClass> allCourses = dbContext.CourseClasses.Where(e => e.ClassID == classId).ToList();

                    if (allCourses.Count > 0)
                    {
                        courseClass = new List<CourseClassVo>();
                        foreach (var item in allCourses)
                        {
                            Course courseObj = dbContext.Courses.Find(item.CourseID);
                            CourseClassVo vo = new CourseClassVo
                            {
                                coursename = courseObj.CourseName,
                                classname = classname.ClassName
                            };
                            courseClass.Add(vo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return courseClass;
        }

        public List<CourseClassVo> DisplayAllClassAssignToCourse(int courseId)
        {
            List < CourseClassVo > courseClass = null;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Course coursename = dbContext.Courses.Find(courseId);
                    List<CourseClass> allClasses = dbContext.CourseClasses.Where(e => e.CourseID == courseId).ToList();

                    if (allClasses.Count > 0)
                    {
                        courseClass = new List<CourseClassVo>();
                        foreach (var item in allClasses)
                        {
                            Class obj = dbContext.Classes.Find(item.ClassID);
                            CourseClassVo vo = new CourseClassVo();
                            vo.coursename=coursename.CourseName;
                            vo.classname = obj.ClassName;
                            courseClass.Add(vo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return courseClass; 
        }

        public bool RemoveCourseToClass(int courseId, int classId)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    var recordToDelete = dbContext.CourseClasses.FirstOrDefault(e => e.CourseID == courseId && e.ClassID == classId);

                    if (recordToDelete != null)
                    {

                        dbContext.CourseClasses.Remove(recordToDelete);
                        dbContext.SaveChanges();

                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public bool DeleteStudent(StudentVO vo)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Student studentToDelete = dbContext.Students.Find(vo.StudentID);

                    if (studentToDelete != null)
                    {
                        dbContext.Students.Remove(studentToDelete);
                        dbContext.SaveChanges();

                        flag=true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public bool AddClass(ClassVO vo)
        {
            bool flag=false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Class newClass = new Class
                    {
                        ClassName = vo.ClassName,
                    };

                    dbContext.Classes.Add(newClass);
                    dbContext.SaveChanges();

                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public List<ClassVO> DisplayAllClasses()
        {
            List<ClassVO> listvo = null;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    dbContext.Database.Log = Console.WriteLine;
                    List<Class> allClasses = dbContext.Classes.ToList();

                    listvo = new List<ClassVO>();
                    foreach (var classObj in allClasses)
                    {
                        ClassVO vo = new ClassVO
                        {
                            ClassID = classObj.ClassID,
                            ClassName = classObj.ClassName
                        };
                        listvo.Add(vo);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return listvo;
        }

        public bool UpdateClass(ClassVO vo)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Class classToUpdate = dbContext.Classes.Find(vo.ClassID);

                    if (classToUpdate != null)
                    {
                        classToUpdate.ClassName = vo.ClassName;
                        dbContext.SaveChanges();

                        flag=true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public bool DeleteClass(ClassVO vo)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Class classToDelete = dbContext.Classes.Find(vo.ClassID);

                    if (classToDelete != null)
                    {
                        dbContext.Classes.Remove(classToDelete);
                        dbContext.SaveChanges();

                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public bool AddCourse(CourseVO vo)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Course newCourse = new Course
                    {
                        CourseName = vo.CourseName,
                    };

                    dbContext.Courses.Add(newCourse);
                    dbContext.SaveChanges();

                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public List<CourseVO> DisplayAllCourses()
        {
            List<CourseVO> coursevo = null;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    List<Course> allCourses = dbContext.Courses.ToList();

                    Console.WriteLine("All Courses:");
                    coursevo = new List<CourseVO>();
                    foreach (var course in allCourses)
                    {
                        CourseVO vo = new CourseVO();
                        vo.CourseName = course.CourseName;
                        vo.CourseID = course.CourseID;
                        coursevo.Add(vo);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return coursevo;
        }

        public bool UpdateCourse(CourseVO vo)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Course courseToUpdate = dbContext.Courses.Find(vo.CourseID);

                    if (courseToUpdate != null)
                    {

                        courseToUpdate.CourseName = vo.CourseName;
                        dbContext.SaveChanges();

                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public bool DeleteCourse(CourseVO vo)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Course courseToDelete = dbContext.Courses.Find(vo.CourseID);

                    if (courseToDelete != null)
                    {
                        dbContext.Courses.Remove(courseToDelete);
                        dbContext.SaveChanges();

                        flag = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public List<StudentVO> DisplayAllStudentsWithName(String str)
        {
            List<StudentVO> ans = null;
            try
            {
                List<StudentVO> allStudentsVo = null;
                using (crudEntities dbContext = new crudEntities())
                {
                    List<Student> allStudents = dbContext.Students.ToList();

                    allStudentsVo = new List<StudentVO>();
                    foreach (var student in allStudents)
                    {
                        StudentVO vo = new StudentVO
                        {
                            Name = student.Name,
                            StudentID = student.StudentID
                        };
                        allStudentsVo.Add(vo);
                    }

                    
                }
                ans = (from s in allStudentsVo where s.Name.Contains(str) select s).ToList();
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }           
            return ans;
        }

        public List<StudentVO> DisplayAllStudentsNameWise()
        {
            List<StudentVO> allStudentsVo = null;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    List<Student> allStudents = dbContext.Students.ToList();

                    allStudentsVo = new List<StudentVO>();
                    foreach (var student in allStudents)
                    {
                        StudentVO vo = new StudentVO
                        {
                            Name = student.Name,
                            StudentID = student.StudentID
                        };
                        allStudentsVo.Add(vo);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return allStudentsVo.OrderBy(s=>s.Name).ThenByDescending(s=>s.StudentID).ToList();
        }
    }
}
