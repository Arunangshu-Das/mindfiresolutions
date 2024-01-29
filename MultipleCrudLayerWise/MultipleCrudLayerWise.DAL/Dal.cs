using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleCrudLayerWise.Utils;

namespace MultipleCrudLayerWise.DAL
{
    public class Dal
    {
        public bool AddStudent(string name, string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {

                    Student newStudent = new Student
                    {
                        Name = name
                    };

                    dbContext.Students.Add(newStudent);
                    dbContext.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }

            return flag;
        }

        public void DisplayAllStudents(string fileName)
        {
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    List<Student> allStudents = dbContext.Students.ToList();

                    Console.WriteLine("All Students:");
                    foreach (var student in allStudents)
                    {
                        Console.WriteLine($"ID: {student.StudentID}, Name: {student.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        public bool DisplayStudent(int studentId,string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Student foundStudent = dbContext.Students.Find(studentId);

                    if (foundStudent != null)
                    {
                        Console.WriteLine($"ID: {foundStudent.StudentID}, Name: {foundStudent.Name}");
                        flag = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool UpdateStudent(int studentId, string newName, string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Student studentToUpdate = dbContext.Students.Find(studentId);

                    if (studentToUpdate != null)
                    {
                        studentToUpdate.Name = newName;
                        dbContext.SaveChanges();

                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool AssignStudentToClass(int studentId, int classId, string fileName)
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
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool DisplayAllStudentAssignToClass(int classId, string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Class classname = dbContext.Classes.Find(classId);
                    List<StudentClass> allStudents = dbContext.StudentClasses.Where(e => e.ClassID == classId).ToList();

                    if (allStudents.Count > 0)
                    {
                        foreach (var item in allStudents)
                        {
                            Student classObj = dbContext.Students.Find(item.StudentID);
                            Console.WriteLine(classObj.Name + " " + classname.ClassName);
                        }
                        flag = true;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool DisplayAllClassAssignToStudent(int studentId, string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Student studentname = dbContext.Students.Find(studentId);
                    List<StudentClass> allClasses = dbContext.StudentClasses.Where(e => e.StudentID == studentId).ToList();

                    if (allClasses.Count > 0)
                    {
                        foreach (var item in allClasses)
                        {
                            Class classObj = dbContext.Classes.Find(item.ClassID);
                            Console.WriteLine(studentname.Name + " " + classObj.ClassName);
                        }
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool RemoveStudentToClass(int studentId, int classId, string fileName)
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

                        Console.WriteLine("Student removed from class successfully.");
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool AssignCourseToClass(int courseId, int classId, string fileName)
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
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool DisplayAllCourseAssignToClass(int classId, string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Class classname = dbContext.Classes.Find(classId);
                    List<CourseClass> allCourses = dbContext.CourseClasses.Where(e => e.ClassID == classId).ToList();

                    if (allCourses.Count > 0)
                    {
                        foreach (var item in allCourses)
                        {
                            Course courseObj = dbContext.Courses.Find(item.CourseID);
                            Console.WriteLine(courseObj.CourseName + " " + classname.ClassName);
                        }
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool DisplayAllClassAssignToCourse(int courseId, string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Course coursename = dbContext.Courses.Find(courseId);
                    List<CourseClass> allClasses = dbContext.CourseClasses.Where(e => e.CourseID == courseId).ToList();

                    if (allClasses.Count > 0)
                    {
                        foreach (var item in allClasses)
                        {
                            Class obj = dbContext.Classes.Find(item.ClassID);
                            Console.WriteLine(coursename.CourseName + " " + obj.ClassName);
                        }
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag; 
        }

        public bool RemoveCourseToClass(int courseId, int classId, string fileName)
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
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool DeleteStudent(int studentId, string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Student studentToDelete = dbContext.Students.Find(studentId);

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
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool AddClass(string className, string fileName)
        {
            bool flag=false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Class newClass = new Class
                    {
                        ClassName = className
                    };

                    dbContext.Classes.Add(newClass);
                    dbContext.SaveChanges();

                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool DisplayAllClasses(string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    List<Class> allClasses = dbContext.Classes.ToList();

                    Console.WriteLine("All Classes:");
                    foreach (var classObj in allClasses)
                    {
                        Console.WriteLine($"ID: {classObj.ClassID}, Name: {classObj.ClassName}");
                    }
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool UpdateClass(int classId, string newClassName, string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Class classToUpdate = dbContext.Classes.Find(classId);

                    if (classToUpdate != null)
                    {
                        classToUpdate.ClassName = newClassName;
                        dbContext.SaveChanges();

                        flag=true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool DeleteClass(int classId, string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Class classToDelete = dbContext.Classes.Find(classId);

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
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool AddCourse(string courseName, string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Course newCourse = new Course
                    {
                        CourseName = courseName
                    };

                    dbContext.Courses.Add(newCourse);
                    dbContext.SaveChanges();

                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool DisplayAllCourses(string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    List<Course> allCourses = dbContext.Courses.ToList();

                    Console.WriteLine("All Courses:");
                    foreach (var course in allCourses)
                    {
                        Console.WriteLine($"ID: {course.CourseID}, Name: {course.CourseName}");
                    }
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool UpdateCourse(int courseId, string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Course courseToUpdate = dbContext.Courses.Find(courseId);

                    if (courseToUpdate != null)
                    {
                        Console.WriteLine("Enter new name:");
                        string newCourseName = Console.ReadLine();

                        courseToUpdate.CourseName = newCourseName;
                        dbContext.SaveChanges();

                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }

        public bool DeleteCourse(int courseId, string fileName)
        {
            bool flag = false;
            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Course courseToDelete = dbContext.Courses.Find(courseId);

                    if (courseToDelete != null)
                    {
                        dbContext.Courses.Remove(courseToDelete);
                        dbContext.SaveChanges();

                        Console.WriteLine("Course deleted successfully.");
                        flag = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
            return flag;
        }
    }
}
