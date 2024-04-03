using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodefirstApproachTest.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        // Navigation property for courses
        public ICollection<CourseStudent> CourseStudents { get; set; }
    }
}
