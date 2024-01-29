using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleCrudLayerWise.Utils;
using MultipleCrudLayerWise.Business;
using static MultipleCrudLayerWise.Utils.Class1;

namespace MultipleCrudLayerWise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
            int id = 0;

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
                    int studentId = 0;
                    int classId = 0;
                    string newName = null;
                    string className= null;
                    string newClassName = null;

                    switch (inputOperation)
                    {
                        case Operation.ADD_STUDENT:
                            Console.WriteLine("Enter Student Name:");
                            string name = Console.ReadLine();
                            if(service.AddStudent(name, fileName)) Console.WriteLine("Student added successfully.");
                            else Console.WriteLine("Student can't added.");
                            break;
                        case Operation.DISPLAY_ALL_STUDENT:
                            service.DisplayAllStudents(fileName);
                            break;
                        case Operation.DISPLAY_STUDENT:
                            Console.WriteLine("Enter Student ID:");
                            studentId = int.Parse(Console.ReadLine());
                            if (!service.DisplayStudent(studentId,fileName)) Console.WriteLine("Error..");
                            break;
                        case Operation.UPDATE_STUDENT:
                            Console.WriteLine("Enter Student ID:");
                            studentId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new name:");
                            newName = Console.ReadLine();
                            if (service.UpdateStudent(studentId,newName , fileName)) Console.WriteLine("Student updated successfully.");
                            else Console.WriteLine("Error..");
                            break;
                        case Operation.ASSIGN_STUDENT_TO_CLASS:
                            Console.WriteLine("Enter Student ID:");
                            studentId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Class ID:");
                            classId = int.Parse(Console.ReadLine());
                            if (service.AssignStudentToClass(studentId, classId, fileName)) Console.WriteLine("Student assigned to class successfully.");
                            else Console.WriteLine("Error..");
                            break;
                        case Operation.DELETE_STUDENT:
                            Console.WriteLine("Enter Student ID:");
                            studentId = int.Parse(Console.ReadLine());
                            if (service.DeleteStudent(studentId,fileName)) Console.WriteLine("Student deleted successfully.");
                            else Console.WriteLine("Error..");
                            break;
                        case Operation.ADD_CLASS:
                            Console.WriteLine("Enter Class Name:");
                            className = Console.ReadLine();
                            if (service.AddClass(className, fileName)) Console.WriteLine("Class added successfully.");
                            else Console.WriteLine("Error..");
                            break;
                        case Operation.DISPLAY_ALL_CLASS:
                            if(!service.DisplayAllClasses(fileName)) Console.WriteLine("Error..");
                            break;
                        case Operation.UPDATE_CLASS:
                            Console.WriteLine("Enter Class ID:");
                            classId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new name:");
                            newClassName = Console.ReadLine();
                            if (service.UpdateClass(classId, newClassName, fileName)) Console.WriteLine("Class updated successfully.");
                            else Console.WriteLine("Error..");
                            break;
                        case Operation.DELETE_CLASS:
                            Console.WriteLine("Enter Class ID:");
                            classId = int.Parse(Console.ReadLine());
                            service.DeleteClass(classId,fileName);
                            break;
                        case Operation.ADD_COURSE:
                            service.AddCourse();
                            break;
                        case Operation.DISPLAY_ALL_COURSE:
                            service.DisplayAllCourses();
                            break;
                        case Operation.UPDATE_COURSE:
                            service.UpdateCourse();
                            break;
                        case Operation.ASSIGN_COURSE_TO_CLASS:
                            service.AssignCourseToClass();
                            break;
                        case Operation.DELETE_COURSE:
                            service.DeleteCourse();
                            break;
                        case Operation.REMOVE_STUDENT_TO_CLASS:
                            service.RemoveStudentToClass();
                            break;
                        case Operation.REMOVE_COURSE_TO_CLASS:
                            service.RemoveCourseToClass();
                            break;
                        case Operation.DISPLAY_ALL_STUDENT_ASSIGNIN_CLASS:
                            service.DisplayAllStudentAssignToClass();
                            break;
                        case Operation.DISPLAY_ALL_CLASS_ASSIGNIN_STUDENT:
                            service.DisplayAllClassAssignToStudent();
                            break;
                        case Operation.DISPLAY_ALL_COURSE_ASSIGNIN_CLASS:
                            service.DisplayAllCourseAssignToClass();
                            break;
                        case Operation.DISPLAY_ALL_CLASS_ASSIGNIN_COURSE:
                            service.DisplayAllClassAssignToCourse();
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
                Logger.AddData(ex, fileName);
            }

            Console.ReadLine();
        }

    }
    }
}
