using System;
using System.Collections.Generic;
using System.Linq;
using MultipleCrudLayerWise.;
using System.Text;
using System.Threading.Tasks;

namespace MultipleCrudLayerWise.DAL
{
    public class Dal
    {
        private void AddStudent(string name, string fileName)
        {
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
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }

            Console.WriteLine("Student added successfully.");
        }

        private void DisplayAllStudents()
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

        private void DisplayStudent()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());

            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Student foundStudent = dbContext.Students.Find(studentId);

                    if (foundStudent != null)
                    {
                        Console.WriteLine($"ID: {foundStudent.StudentID}, Name: {foundStudent.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void UpdateStudent()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());

            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Student studentToUpdate = dbContext.Students.Find(studentId);

                    if (studentToUpdate != null)
                    {
                        Console.WriteLine("Enter new name:");
                        string newName = Console.ReadLine();

                        studentToUpdate.Name = newName;
                        dbContext.SaveChanges();

                        Console.WriteLine("Student updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void AssignStudentToClass()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

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

                        Console.WriteLine("Student assigned to class successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student or Class not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void DisplayAllStudentAssignToClass()
        {
            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

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
                    }
                    else
                    {
                        Console.WriteLine("Student or Class not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void DisplayAllClassAssignToStudent()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());
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
                    }
                    else
                    {
                        Console.WriteLine("Student or Class not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void RemoveStudentToClass()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

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
                    }
                    else
                    {
                        Console.WriteLine("Student or Class not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void AssignCourseToClass()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

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

                        Console.WriteLine("Student assigned to class successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student or Class not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void DisplayAllCourseAssignToClass()
        {
            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

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
                    }
                    else
                    {
                        Console.WriteLine("Course or Class not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void DisplayAllClassAssignToCourse()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());

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
                    }
                    else
                    {
                        Console.WriteLine("Course or Class not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void RemoveCourseToClass()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    var recordToDelete = dbContext.CourseClasses.FirstOrDefault(e => e.CourseID == courseId && e.ClassID == classId);

                    if (recordToDelete != null)
                    {

                        dbContext.CourseClasses.Remove(recordToDelete);
                        dbContext.SaveChanges();

                        Console.WriteLine("Student Removed from class successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student or Class not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void DeleteStudent()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());

            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Student studentToDelete = dbContext.Students.Find(studentId);

                    if (studentToDelete != null)
                    {
                        dbContext.Students.Remove(studentToDelete);
                        dbContext.SaveChanges();

                        Console.WriteLine("Student deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void AddClass()
        {
            Console.WriteLine("Enter Class Name:");
            string className = Console.ReadLine();

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

                    Console.WriteLine("Class added successfully.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void DisplayAllClasses()
        {
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
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void UpdateClass()
        {
            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Class classToUpdate = dbContext.Classes.Find(classId);

                    if (classToUpdate != null)
                    {
                        Console.WriteLine("Enter new name:");
                        string newClassName = Console.ReadLine();

                        classToUpdate.ClassName = newClassName;
                        dbContext.SaveChanges();

                        Console.WriteLine("Class updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Class not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void DeleteClass()
        {
            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

            try
            {
                using (crudEntities dbContext = new crudEntities())
                {
                    Class classToDelete = dbContext.Classes.Find(classId);

                    if (classToDelete != null)
                    {
                        dbContext.Classes.Remove(classToDelete);
                        dbContext.SaveChanges();

                        Console.WriteLine("Class deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Class not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void AddCourse()
        {
            Console.WriteLine("Enter Course Name:");
            string courseName = Console.ReadLine();

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

                    Console.WriteLine("Course added successfully.");
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void DisplayAllCourses()
        {
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
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void UpdateCourse()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());

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

                        Console.WriteLine("Course updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Course not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }

        private void DeleteCourse()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());

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
                    }
                    else
                    {
                        Console.WriteLine("Course not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }
        }
    }
}
