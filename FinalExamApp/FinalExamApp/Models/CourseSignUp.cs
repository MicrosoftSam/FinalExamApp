using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamApp.Models
{
    public class CourseSignUp
    {
        public int CourseSignUpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public int CourseId { get; set; }
        public bool Status { get; set; }

        public string FullName =>
            FirstName + " " +  LastName;
    }
}
