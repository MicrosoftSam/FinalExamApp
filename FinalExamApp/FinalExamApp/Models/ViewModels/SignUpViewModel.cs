using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamApp.Models.ViewModels
{
    public class SignUpViewModel
    {
        public IEnumerable<CourseSignUp> CourseSignUps { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
