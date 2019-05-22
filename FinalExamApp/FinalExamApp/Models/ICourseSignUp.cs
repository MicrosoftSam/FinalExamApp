using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamApp.Models
{
    public interface ICourseSignUp
    {
        IQueryable<CourseSignUp> CourseSignUps { get; }
    }
}
