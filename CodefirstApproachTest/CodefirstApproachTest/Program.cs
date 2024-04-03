using CodefirstApproachTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;


//using (var dbContext = new MyDataBaseDbContext())
//{
//    dbContext.Database.EnsureCreated();
//}

static void StartApplication()
{
    bool exit = false;
    while (!exit)
    {
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Add Course");
        Console.WriteLine("3. Add Teacher");
        Console.WriteLine("4. Assign Student to a Course");
        Console.WriteLine("5. Assign Teacher to a Course");
        Console.WriteLine("6. Remove Teacher from a Course");
        Console.WriteLine("7. Remove Student from a Course");
        Console.WriteLine("8. Delete Student");
        Console.WriteLine("9. Delete Course");
        Console.WriteLine("10. Delete Teacher");
        Console.WriteLine("11. Show All Students");
        Console.WriteLine("12. Show All Students in a course");
        Console.WriteLine("13. Show All Students in all course");
        Console.WriteLine("14. Show all Teachers");
        Console.WriteLine("15. Show all Courses");
        Console.WriteLine("16. Update Student");
        Console.WriteLine("17. Update Course");
        Console.WriteLine("18. Update Teacher");
        Console.WriteLine("19. Exit");
        Console.Write("Select an option: ");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    AddCourse();
                    break;
                case 3:
                    AddTeacher();
                    break;
                case 4:
                    AssignStudentToCourse();
                    break;
                case 5:
                    AssignTeacherToCourse();
                    break;
                case 6:
                    RemoveTeacherFromCourse();
                    break;
                case 7:
                    RemoveStudentFromCourse();
                    break;
                case 8:
                    DeleteStudent();
                    break;
                case 9:
                    DeleteCourse();
                    break;
                case 10:
                    DeleteTeacher();
                    break;
                case 11:
                    ShowAllStudents();
                    break;
                case 12:
                    Console.WriteLine("Enter Course id");
                    int id = int.Parse(Console.ReadLine());
                    ShowAllStudentsInCourse(id);
                    break;
                case 13:
                    ShowAllStudentsInAllCourses();
                    break;
                case 14:
                    ShowAllTeachers();
                    break;
                case 15:
                    ShowAllCourses();
                    break;
                case 16:
                    UpdateStudent();
                    break;
                case 17:
                    UpdateCourse();
                    break;
                case 18:
                    UpdateTeacher();
                    break;
                case 19:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid option.");
        }

        Console.WriteLine();
    }
}

static void AddStudent()
{
    Console.Write("Enter student name: ");
    string name = Console.ReadLine();
    var student = new Student { Name = name };
    var _context = new MyDataBaseDbContext();
    _context.Students.Add(student);
    _context.SaveChanges();
    Console.WriteLine("Student added successfully.");
}

static void AddCourse()
{
    Console.Write("Enter course name: ");
    string name = Console.ReadLine();
    Console.Write("Enter teacher id for the course: ");
    int teacherId = int.Parse(Console.ReadLine());
    var course = new Course { Name = name, TeacherId = teacherId };
    var _context = new MyDataBaseDbContext();
    _context.Courses.Add(course);
    _context.SaveChanges();
    Console.WriteLine("Course added successfully.");
}

 static void AddTeacher()
{
    Console.Write("Enter teacher name: ");
    string name = Console.ReadLine();
    var teacher = new Teacher { Name = name };
    var _context = new MyDataBaseDbContext();
    _context.Teachers.Add(teacher);
    _context.SaveChanges();
    Console.WriteLine("Teacher added successfully.");
}

static void UpdateStudent()
{
    Console.Write("Enter student ID to update: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Enter new student name: ");
    string newName = Console.ReadLine();

    var _context = new MyDataBaseDbContext();
    var student = _context.Students.FirstOrDefault(s => s.StudentId == id);
    if (student != null)
    {
        student.Name = newName;
        _context.SaveChanges();
        Console.WriteLine("Student updated successfully.");
    }
    else
    {
        Console.WriteLine("Student not found.");
    }
}

static void UpdateCourse()
{
    Console.Write("Enter course ID to update: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Enter new course name: ");
    string newName = Console.ReadLine();
    Console.Write("Enter new teacher ID for the course: ");
    int newTeacherId = int.Parse(Console.ReadLine());

    var _context = new MyDataBaseDbContext();
    var course = _context.Courses.FirstOrDefault(c => c.CourseId == id);
    if (course != null)
    {
        course.Name = newName;
        course.TeacherId = newTeacherId;
        _context.SaveChanges();
        Console.WriteLine("Course updated successfully.");
    }
    else
    {
        Console.WriteLine("Course not found.");
    }
}

static void UpdateTeacher()
{
    Console.Write("Enter teacher ID to update: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Enter new teacher name: ");
    string newName = Console.ReadLine();

    var _context = new MyDataBaseDbContext();
    var teacher = _context.Teachers.FirstOrDefault(t => t.TeacherId == id);
    if (teacher != null)
    {
        teacher.Name = newName;
        _context.SaveChanges();
        Console.WriteLine("Teacher updated successfully.");
    }
    else
    {
        Console.WriteLine("Teacher not found.");
    }
}


static void AssignStudentToCourse()
{
    Console.Write("Enter student id: ");
    int studentId = int.Parse(Console.ReadLine());
    Console.Write("Enter course id: ");
    int courseId = int.Parse(Console.ReadLine());
    var _context = new MyDataBaseDbContext();

    var course = _context.Courses.Find(courseId);
    var student = _context.Students.Find(studentId);
    var alreadyenrolled = _context.CourseStudents.Where(cs=>cs.StudentId==studentId && cs.CourseId==courseId).FirstOrDefault();

    if (course != null && student != null && alreadyenrolled==null)
    {
        var coursestudent = new CourseStudent { StudentId = studentId, CourseId = courseId };
        _context.CourseStudents.Add(coursestudent);
        _context.SaveChanges();
        Console.WriteLine("Student assigned to course successfully.");
    }
    else if (alreadyenrolled != null)
    {
        Console.WriteLine("Already enrolled");
    }
    else
    {
        Console.WriteLine("Course or student not found.");
    }
}

 static void AssignTeacherToCourse()
{
    Console.Write("Enter teacher id: ");
    int teacherId = int.Parse(Console.ReadLine());
    Console.Write("Enter course id: ");
    int courseId = int.Parse(Console.ReadLine());
    var _context = new MyDataBaseDbContext();

    var course = _context.Courses.Find(courseId);
    var teacher = _context.Teachers.Find(teacherId);

    if (course != null && teacher != null)
    {
        course.TeacherId = teacherId;
        _context.SaveChanges();
        Console.WriteLine("Teacher assigned to course successfully.");
    }
    else
    {
        Console.WriteLine("Course or teacher not found.");
    }
}

 static void RemoveTeacherFromCourse()
{
    Console.Write("Enter course id: ");
    int courseId = int.Parse(Console.ReadLine());
    var _context = new MyDataBaseDbContext();

    var course = _context.Courses.Find(courseId);

    if (course != null)
    {
        course.TeacherId = 0;
        _context.SaveChanges();
        Console.WriteLine("Teacher removed from course successfully.");
    }
    else
    {
        Console.WriteLine("Course not found.");
    }
}

 static void RemoveStudentFromCourse()
{
    Console.Write("Enter student id: ");
    int studentId = int.Parse(Console.ReadLine());
    Console.Write("Enter course id: ");
    int courseId = int.Parse(Console.ReadLine());
    var _context = new MyDataBaseDbContext();

    var coursestudent = _context.CourseStudents.Find(courseId==courseId && studentId==studentId);

    if (coursestudent != null)
    {
        _context.CourseStudents.Remove(coursestudent);
        _context.SaveChanges();
        Console.WriteLine("Student removed from course successfully.");
    }
    else
    {
        Console.WriteLine("Course or student not found.");
    }
}

 static void DeleteStudent()
{
    Console.Write("Enter student id: ");
    int studentId = int.Parse(Console.ReadLine());
    var _context = new MyDataBaseDbContext();
    var student = _context.Students.Find(studentId);

    if (student != null)
    {
        _context.Students.Remove(student);
        _context.SaveChanges();
        Console.WriteLine("Student deleted successfully.");
    }
    else
    {
        Console.WriteLine("Student not found.");
    }
}

 static void DeleteCourse()
{
    var _context = new MyDataBaseDbContext();
    Console.Write("Enter course id: ");
    int courseId = int.Parse(Console.ReadLine());
    var course = _context.Courses.Find(courseId);

    if (course != null)
    {
        _context.Courses.Remove(course);
        _context.SaveChanges();
        Console.WriteLine("Course deleted successfully.");
    }
    else
    {
        Console.WriteLine("Course not found.");
    }
}

 static void DeleteTeacher()
{
    Console.Write("Enter teacher id: ");
    var _context = new MyDataBaseDbContext();
    int teacherId = int.Parse(Console.ReadLine());
    var teacher = _context.Teachers.Find(teacherId);

    if (teacher != null)
    {
        _context.Teachers.Remove(teacher);
        _context.SaveChanges();
        Console.WriteLine("Teacher deleted successfully.");
    }
    else
    {
        Console.WriteLine("Teacher not found.");
    }
}

 static void ShowAllStudents()
{
    var _context = new MyDataBaseDbContext();
    var students = _context.Students.ToList();
    Console.WriteLine("List of all students:");
    foreach (var student in students)
    {
        Console.WriteLine($"ID: {student.StudentId}, Name: {student.Name}");
    }
}

 static void ShowAllStudentsInCourse(int courseId)
{
    var _context = new MyDataBaseDbContext();
    var studentsInCourse = _context.CourseStudents
            .Where(cs => cs.CourseId == courseId)
            .Select(cs => cs.Student.Name)
            .ToList();

    if (studentsInCourse.Any())
    {
        Console.WriteLine("Students:");
        foreach (var studentName in studentsInCourse)
        {
            Console.WriteLine($"- {studentName}");
        }
    }
    else
    {
        Console.WriteLine("No students enrolled in this course.");
    }
}

static void ShowAllTeachers()
{
    var _context = new MyDataBaseDbContext();
    var teachers = _context.Teachers.ToList();
    Console.WriteLine("List of all Teachers:");
    foreach (var teacher in teachers)
    {
        Console.WriteLine($"ID: {teacher.TeacherId}, Name: {teacher.Name}");
    }
}

static void ShowAllCourses()
{
    var _context = new MyDataBaseDbContext();
    var courses = _context.Courses.ToList();
    Console.WriteLine("List of all courses:");
    foreach (var course in courses)
    {
        Console.WriteLine($"ID: {course.CourseId}, Name: {course.Name}");
    }
}

static void ShowAllStudentsInAllCourses()
{
    var _context = new MyDataBaseDbContext();
    var allCourses = _context.Courses.ToList();

    Console.WriteLine($"Students in All Courses:");

    foreach (var course in allCourses)
    {
        var studentsInCourse = _context.CourseStudents
            .Where(cs => cs.CourseId == course.CourseId)
            .Select(cs => cs.Student.Name)
            .ToList();

        Console.WriteLine($"Course: {course.Name}");

        if (studentsInCourse.Any())
        {
            Console.WriteLine("Students:");
            foreach (var studentName in studentsInCourse)
            {
                Console.WriteLine($"- {studentName}");
            }
        }
        else
        {
            Console.WriteLine("No students enrolled in this course.");
        }

        Console.WriteLine();
    }
}


StartApplication();