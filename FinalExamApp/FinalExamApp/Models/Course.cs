using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime CourseStartDate { get; set; }
        public bool Full { get; set; }
        public string Category { get; set; }
    }
}
