using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamApp.Models
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }
        void SaveCourse(Course course);
        void EditCourse(Course course);
        void DeleteCourse(int courseId);
    }
}
