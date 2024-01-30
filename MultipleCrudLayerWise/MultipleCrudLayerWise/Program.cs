using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleCrudLayerWise.Utils;
using MultipleCrudLayerWise.Business;
using MultipleCrudLayerWise.models;
using static MultipleCrudLayerWise.Utils.Class1;
using System.Runtime.Remoting.Contexts;

namespace MultipleCrudLayerWise
{
    internal class Program
    {
        static Service service = null;
        static void Main(string[] args)
        {
            service = new Service();
            int id = 0;
            Program program = new Program();

            String fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";

            try
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
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
                            program.DisplayAllStudent();
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
                            program.DisplayAllClass();
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
                            program.DisplayAllCourse();
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
                            program.DisplayAllStudentInClass();
                            break;
                        case Operation.DISPLAY_ALL_CLASS_ASSIGNIN_STUDENT:
                            program.DisplayAllClassInStudent();
                            break;
                        case Operation.DISPLAY_ALL_COURSE_ASSIGNIN_CLASS:
                            program.DisplayAllCourseInClass();
                            break;
                        case Operation.DISPLAY_ALL_CLASS_ASSIGNIN_COURSE:
                            program.DisplayAllClassInCourse();
                            break;
                        case Operation.EXIT:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Error.WriteLine("Enter a valid choice");
                            break;
                    }

                } while (id != 22);
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            Console.ReadLine();
        }


        private void AddStudent()
        {
            Console.WriteLine("Enter Student Name:");
            string name = Console.ReadLine();
            StudentVO studentvo = new StudentVO();
            studentvo.Name = name;
            if (service.AddStudent(studentvo))
            {
                Console.WriteLine("Student added successfully.");
            }
            else
            {
                Console.WriteLine("Student can't added.");
            }
        }

        private void DisplayAllStudent()
        {
            List<StudentVO> allStudents = service.DisplayAllStudents();
            foreach (var student in allStudents)
            {
                Console.WriteLine($"ID: {student.StudentID}, Name: {student.Name}");
            }
        }

        private void DisplayStudent()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());
            StudentVO foundStudent = service.DisplayStudent(studentId);

            if (foundStudent != null)
            {
                Console.WriteLine($"ID: {foundStudent.StudentID}, Name: {foundStudent.Name}");
            }
        }

        private void UpdateStudent()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new name:");
            String newName = Console.ReadLine();
            StudentVO studentvo = new StudentVO();
            studentvo.StudentID = studentId;
            studentvo.Name = newName;
            if (service.UpdateStudent(studentvo))
            {
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("Error..");
            }
        }

        private void AssignStudentToClass()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());
            if (service.AssignStudentToClass(studentId, classId))
            {
                Console.WriteLine("Student assigned to class successfully.");
            }
            else
            {
                Console.WriteLine("Error..");
            }
        }

        private void DeleteStudent()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());
            StudentVO studentvo = new StudentVO();
            studentvo.StudentID = studentId;
            if (service.DeleteStudent(studentvo))
            {
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Error..");
            }
        }

        private void AddClass()
        {
            Console.WriteLine("Enter Class Name:");
            String className = Console.ReadLine();
            ClassVO classvo = new ClassVO();
            classvo.ClassName = className;
            if (service.AddClass(classvo))
            {
                Console.WriteLine("Class added successfully.");
            }
            else
            {
                Console.WriteLine("Error..");
            }
        }
        private void DisplayAllClass()
        {
            List<ClassVO> allClass = service.DisplayAllClasses();
            if (allClass != null)
            {
                foreach (var classObj in allClass)
                {
                    Console.WriteLine($"ID: {classObj.ClassID}, Name: {classObj.ClassName}");
                }
            } else
            {
                Console.WriteLine("Error..");
            }
        }

        private void UpdateClass(){
            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new name:");
            String newClassName = Console.ReadLine();
            ClassVO classvo = new ClassVO();
            classvo.ClassID = classId;
            classvo.ClassName = newClassName;
            if (service.UpdateClass(classvo))
            {
                Console.WriteLine("Class updated successfully.");
            }
            else
            {
                Console.WriteLine("Error..");
            }
        }

        private void DeleteClass()
        {
            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());
            ClassVO classvo = new ClassVO();
            classvo.ClassID = classId;
            if (service.DeleteClass(classvo))
            {
                Console.WriteLine("Class deleted successfully.");
            }
            else
            {
                Console.WriteLine("Error..");
            }
        }

        private void AddCourse()
        {
            Console.WriteLine("Enter Course Name:");
            string courseName = Console.ReadLine();
            CourseVO coursevo = new CourseVO();
            coursevo.CourseName = courseName;
            if (service.AddCourse(coursevo))
            {
                Console.WriteLine("Course deleted successfully.");
            }
            else
            {
                Console.WriteLine("Error..");
            }
        }

        private void DisplayAllCourse()
        {
            List<CourseVO> allCourses = service.DisplayAllCourses();
            if (allCourses != null)
            {
                foreach (var course in allCourses)
                {
                    Console.WriteLine($"ID: {course.CourseID}, Name: {course.CourseName}");
                }
            }
        }

        private void UpdateCourse()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new name:");
            string newCourseName = Console.ReadLine();
            CourseVO coursevo = new CourseVO();
            coursevo.CourseName = newCourseName;
            coursevo.CourseID = courseId;
            if (service.UpdateCourse(coursevo))
            {
                Console.WriteLine("Course updated successfully.");
            }
            else
            {
                Console.WriteLine("Error..");
            }
        }

        private void AssignCourseToClass()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

            if (service.AssignCourseToClass(courseId, classId))
            {
                Console.WriteLine("Course assigned to class successfully.");
            }
            else
            {
                Console.WriteLine("Error..");
            }
        }

        private void DeleteCourse()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());
            CourseVO coursevo = new CourseVO();
            coursevo.CourseID = courseId;
            if (service.DeleteCourse(coursevo))
            {
                Console.WriteLine("Course deleted successfully.");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        private void RemoveStudentToClass()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());
            if (service.RemoveStudentToClass(studentId, classId))
            {
                Console.WriteLine("Student removed from class successfully.");
            }
            else
            {
                Console.WriteLine("Error..");
            }
        }

        private void RemoveCourseToClass()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());

            if (service.RemoveCourseToClass(courseId, classId))
            {
                Console.WriteLine("Course Removed from class successfully.");
            }
            else
            {
                Console.WriteLine("Course or Class not found.");
            }
        }

        private void DisplayAllStudentInClass()
        {
            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());
            List<StudentClassVo> allStudents = service.DisplayAllStudentAssignToClass(classId);
            if (allStudents != null)
            {
                foreach (var item in allStudents)
                {
                    Console.WriteLine(item.studentname + " " + item.classname);
                }
            }
        }

        private void DisplayAllClassInStudent()
        {
            Console.WriteLine("Enter Student ID:");
            int studentId = int.Parse(Console.ReadLine());
            List<StudentClassVo> allClass = service.DisplayAllClassAssignToStudent(studentId);

            if (allClass != null)
            {
                foreach (var item in allClass)
                {
                    Console.WriteLine(item.studentname+" "+item.classname);
                }
            }
        }

        private void DisplayAllCourseInClass()
        {
            Console.WriteLine("Enter Class ID:");
            int classId = int.Parse(Console.ReadLine());
            List<CourseClassVo> allCourses = service.DisplayAllCourseAssignToClass(classId);
            if (allCourses != null)
            {
                foreach (var item in allCourses)
                {
                    Console.WriteLine(item.classname + " " + item.coursename);
                }
            }
        }

        private void DisplayAllClassInCourse()
        {
            Console.WriteLine("Enter Course ID:");
            int courseId = int.Parse(Console.ReadLine());
            List<CourseClassVo> allClass = service.DisplayAllClassAssignToCourse(courseId);

            if (allClass != null)
            {
                foreach (var item in allClass)
                {
                    Console.WriteLine(item.classname + " " + item.coursename);
                }
            }
        }
    }
}
