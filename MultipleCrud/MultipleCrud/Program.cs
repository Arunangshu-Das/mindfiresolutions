using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleCrud
{
    internal class Program
    {
        private crudEntities dbContext = new crudEntities(); // Replace with your actual DbContext

        static void Main(string[] args)
        {
            Program program = new Program();
            int id = 0;

            do
            {
                Console.WriteLine("\n 1. Add Student");
                Console.WriteLine("\n 2. Display All Students");
                Console.WriteLine("\n 3. Display Student");
                Console.WriteLine("\n 4. Update Student");
                Console.WriteLine("\n 5. Assign Student to class");
                Console.WriteLine("\n 6. Delete Student");
                Console.WriteLine("\n 7. Add Class");
                Console.WriteLine("\n 8. Display All Class");
                Console.WriteLine("\n 9. Update Class");
                Console.WriteLine("\n 10. Delete class");
                Console.WriteLine("\n 11. Add Course");
                Console.WriteLine("\n 12. Display All Course");
                Console.WriteLine("\n 13. Update Course");
                Console.WriteLine("\n 14. Assign Course to class");
                Console.WriteLine("\n 15. Delete Course");
                Console.WriteLine("\n 16. Exit");

                id = int.Parse(Console.ReadLine());

                switch (id)
                {
                    case 1:
                        program.AddStudent();
                        break;
                    case 2:
                        program.DisplayAllStudents();
                        break;
                    case 3:
                        program.DisplayStudent();
                        break;
                    case 4:
                        program.UpdateStudent();
                        break;
                    case 5:
                        program.AssignStudentToClass();
                        break;
                    case 6:
                        program.DeleteStudent();
                        break;
                    case 7:
                        program.AddClass();
                        break;
                    case 8:
                        program.DisplayAllClasses();
                        break;
                    case 9:
                        program.UpdateClass();
                        break;
                    case 10:
                        program.DeleteClass();
                        break;
                    case 11:
                        program.AddCourse();
                        break;
                    case 12:
                        program.DisplayAllCourses();
                        break;
                    case 13:
                        program.UpdateCourse();
                        break;
                    case 14:
                        program.AssignCourseToClass();
                        break;
                    case 15:
                        program.DeleteCourse();
                        break;
                    case 16:
                        Console.WriteLine("Exiting program.");
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice");
                        break;
                }

            } while (id != 16);

            Console.ReadLine();
        }

        private void AddStudent()
        {
            Console.WriteLine("Enter Student Name:");
            string name = Console.ReadLine();

            Student newStudent = new Student
            {
                Name = name
            };

            dbContext.Students.Add(newStudent);
            dbContext.SaveChanges();

            Console.WriteLine("Student added successfully.");
        }

        private void DisplayAllStudents()
        {
            List<Student> allStudents = dbContext.Students.ToList();

            Console.WriteLine("All Students:");
            foreach (var student in allStudents)
            {
                Console.WriteLine($"ID: {student.StudentID}, Name: {student.Name}");
            }
        }

        private void DisplayStudent()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());

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

        private void UpdateStudent()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());

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

        private void AssignStudentToClass()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

            Student student = dbContext.Students.Find(studentId);
            Class classObj = dbContext.Classes.Find(classId);

            if (student != null && classObj != null)
            {
                classObj.Students.Add(student);
                dbContext.SaveChanges();

                Console.WriteLine("Student assigned to class successfully.");
            }
            else
            {
                Console.WriteLine("Student or Class not found.");
            }
        }

        private void AssignCourseToClass()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

            Course course = dbContext.Courses.Find(courseId);
            Class classObj = dbContext.Classes.Find(classId);

            if (course != null && classObj != null)
            {
                classObj.courses.Add(course);
                dbContext.SaveChanges();

                Console.WriteLine("Student assigned to class successfully.");
            }
            else
            {
                Console.WriteLine("Student or Class not found.");
            }
        }

        private void DeleteStudent()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());

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

        private void AddClass()
        {
            Console.WriteLine("Enter Class Name:");
            string className = Console.ReadLine();

            Class newClass = new Class
            {
                ClassName = className
            };

            dbContext.Classes.Add(newClass);
            dbContext.SaveChanges();

            Console.WriteLine("Class added successfully.");
        }

        private void DisplayAllClasses()
        {
            List<Class> allClasses = dbContext.Classes.ToList();

            Console.WriteLine("All Classes:");
            foreach (var classObj in allClasses)
            {
                Console.WriteLine($"ID: {classObj.ClassID}, Name: {classObj.ClassName}");
            }
        }

        private void UpdateClass()
        {
            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

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

        private void DeleteClass()
        {
            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

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

        private void AddCourse()
        {
            Console.WriteLine("Enter Course Name:");
            string courseName = Console.ReadLine();

            Course newCourse = new Course
            {
                CourseName = courseName
            };

            dbContext.Courses.Add(newCourse);
            dbContext.SaveChanges();

            Console.WriteLine("Course added successfully.");
        }

        private void DisplayAllCourses()
        {
            List<Course> allCourses = dbContext.Courses.ToList();

            Console.WriteLine("All Courses:");
            foreach (var course in allCourses)
            {
                Console.WriteLine($"ID: {course.CourseID}, Name: {course.CourseName}");
            }
        }

        private void UpdateCourse()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());

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

        private void DeleteCourse()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());

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
}
