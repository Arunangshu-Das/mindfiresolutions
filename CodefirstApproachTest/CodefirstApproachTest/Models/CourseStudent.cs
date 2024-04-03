using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodefirstApproachTest.Models
{
    public class CourseStudent
    {
        public int CourseStudentId { get; set; } // Added ID property
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
