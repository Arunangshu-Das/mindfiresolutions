using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrudOperationInManytoMany
{
    internal class Program
    {
        //private crudEntities dbContext = new crudEntities(); 

        static String fileName = "";

        public enum Operation
        {
            ADD_STUDENT=1, 
            DISPLAY_ALL_STUDENT, 
            DISPLAY_STUDENT, 
            UPDATE_STUDENT,
            ASSIGN_STUDENT_TO_CLASS,
            DELETE_STUDENT,
            ADD_CLASS, 
            DISPLAY_ALL_CLASS, 
            UPDATE_CLASS, 
            DELETE_CLASS,
            ADD_COURSE, 
            DISPLAY_ALL_COURSE, 
            UPDATE_COURSE, 
            ASSIGN_COURSE_TO_CLASS,
            DELETE_COURSE,
            REMOVE_STUDENT_TO_CLASS,
            REMOVE_COURSE_TO_CLASS, 
            DISPLAY_ALL_STUDENT_ASSIGNIN_CLASS,
            DISPLAY_ALL_CLASS_ASSIGNIN_STUDENT, 
            DISPLAY_ALL_COURSE_ASSIGNIN_CLASS, 
            DISPLAY_ALL_CLASS_ASSIGNIN_COURSE, 
            EXIT
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            int id = 0;

            fileName=DateTime.Now.ToString("yyyyMMdd")+".txt";

            try
            {
                do
                {
                    Console.ForegroundColor=ConsoleColor.White;
                    Console.WriteLine($"\n {(int)Operation.ADD_STUDENT}. Add Student");
                    Console.WriteLine($"\n {(int)Operation.DISPLAY_ALL_STUDENT}. Display All Students");
                    Console.WriteLine($"\n {(int)Operation.DISPLAY_STUDENT}. Display Student");
                    Console.WriteLine($"\n {(int)Operation.UPDATE_STUDENT}. Update Student");
                    Console.WriteLine($"\n {(int)Operation.ASSIGN_STUDENT_TO_CLASS}. Assign Student to class");
                    Console.WriteLine($"\n {(int)Operation.DELETE_STUDENT}. Delete Student");
                    Console.WriteLine($"\n {(int)Operation.ADD_CLASS}. Add Class");
                    Console.WriteLine($"\n {(int)Operation.DISPLAY_ALL_CLASS}. Display All Class");
                    Console.WriteLine($"\n {(int)Operation.UPDATE_CLASS}. Update Class");
                    Console.WriteLine($"\n {(int)Operation.DELETE_CLASS}. Delete class");
                    Console.WriteLine($"\n {(int)Operation.ADD_COURSE}. Add Course");
                    Console.WriteLine($"\n {(int)Operation.DISPLAY_ALL_COURSE}. Display All Course");
                    Console.WriteLine($"\n {(int)Operation.UPDATE_COURSE}. Update Course");
                    Console.WriteLine($"\n {(int)Operation.ASSIGN_COURSE_TO_CLASS}. Assign Course to class");
                    Console.WriteLine($"\n {(int)Operation.DELETE_COURSE}. Delete Course");
                    Console.WriteLine($"\n {(int)Operation.REMOVE_STUDENT_TO_CLASS}. Remove Student to class");
                    Console.WriteLine($"\n {(int)Operation.REMOVE_COURSE_TO_CLASS}. Remove Course to class");
                    Console.WriteLine($"\n {(int)Operation.DISPLAY_ALL_STUDENT_ASSIGNIN_CLASS}. Display all Students assigned in Class");
                    Console.WriteLine($"\n {(int)Operation.DISPLAY_ALL_CLASS_ASSIGNIN_STUDENT}. Display all Classes assigned in Student");
                    Console.WriteLine($"\n {(int)Operation.DISPLAY_ALL_COURSE_ASSIGNIN_CLASS}. Display all Course assigned in Class");
                    Console.WriteLine($"\n {(int)Operation.DISPLAY_ALL_CLASS_ASSIGNIN_COURSE}. Display all Classes assigned in Course");
                    Console.WriteLine($"\n {(int)Operation.EXIT}. Exit");
                    id = int.Parse(Console.ReadLine());
                    Operation inputOperation = (Operation)id;

                    switch (inputOperation)
                    {
                        case Operation.ADD_STUDENT:
                            program.AddStudent();
                            break;
                        case Operation.DISPLAY_ALL_STUDENT:
                            program.DisplayAllStudents();
                            break;
                        case Operation.DISPLAY_STUDENT:
                            program.DisplayStudent();
                            break;
                        case Operation.UPDATE_STUDENT:
                            program.UpdateStudent();
                            break;
                        case Operation.ASSIGN_STUDENT_TO_CLASS:
                            program.AssignStudentToClass();
                            break;
                        case Operation.DELETE_STUDENT:
                            program.DeleteStudent();
                            break;
                        case Operation.ADD_CLASS:
                            program.AddClass();
                            break;
                        case Operation.DISPLAY_ALL_CLASS:
                            program.DisplayAllClasses();
                            break;
                        case Operation.UPDATE_CLASS:
                            program.UpdateClass();
                            break;
                        case Operation.DELETE_CLASS:
                            program.DeleteClass();
                            break;
                        case Operation.ADD_COURSE:
                            program.AddCourse();
                            break;
                        case Operation.DISPLAY_ALL_COURSE:
                            program.DisplayAllCourses();
                            break;
                        case Operation.UPDATE_COURSE:
                            program.UpdateCourse();
                            break;
                        case Operation.ASSIGN_COURSE_TO_CLASS:
                            program.AssignCourseToClass();
                            break;
                        case Operation.DELETE_COURSE:
                            program.DeleteCourse();
                            break;
                        case Operation.REMOVE_STUDENT_TO_CLASS:
                            program.RemoveStudentToClass();
                            break;
                        case Operation.REMOVE_COURSE_TO_CLASS:
                            program.RemoveCourseToClass();
                            break;
                        case Operation.DISPLAY_ALL_STUDENT_ASSIGNIN_CLASS:
                            program.DisplayAllStudentAssignToClass();
                            break;
                        case Operation.DISPLAY_ALL_CLASS_ASSIGNIN_STUDENT:
                            program.DisplayAllClassAssignToStudent();
                            break;
                        case Operation.DISPLAY_ALL_COURSE_ASSIGNIN_CLASS:
                            program.DisplayAllCourseAssignToClass();
                            break;
                        case Operation.DISPLAY_ALL_CLASS_ASSIGNIN_COURSE:
                            program.DisplayAllClassAssignToCourse();
                            break;
                        case Operation.EXIT:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.ForegroundColor=ConsoleColor.Red;
                            Console.Error.WriteLine("Enter a valid choice");
                            break;
                    }

                } while (id != 22);
            }
            catch (Exception ex)
            {
                Logger.AddData(ex, fileName);
            }

            Console.ReadLine();
        }

        private void AddStudent()
        {
            Console.WriteLine("Enter Student Name:");
            string name = Console.ReadLine();

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
            catch(Exception ex)
            {
                Logger.AddData(ex,fileName);
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
