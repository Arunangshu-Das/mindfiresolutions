using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodefirstApproachTest.Models
{
    public class Course
    {

        public int CourseId { get; set; }
        public string Name { get; set; }

        // Foreign key property
        public int TeacherId { get; set; }

        // Navigation property for teacher
        public Teacher Teacher { get; set; }

        // Navigation property for students
        public ICollection<CourseStudent> CourseStudents { get; set; }
    }
}
