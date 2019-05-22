using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamApp.Models
{
    public class EFRepository : ICourseRepository
    {
        private ApplicationDbContext _context;

        public EFRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Course> Courses => _context.Courses;

        public void DeleteCourse(int courseId)
        {
            Course dbEntry = _context.Courses.Where(c =>
                c.CourseId == courseId).FirstOrDefault();

            if(dbEntry != null)
            {
                _context.Courses.Remove(dbEntry);
                _context.SaveChanges();
            }
        }

        public void EditCourse(Course course)
        {
            if(course.CourseId == 0)
            {
                _context.Add(course);
            }
            else
            {
                Course dbEntry = _context.Courses
                    .Where(c => c.CourseId == course.CourseId).FirstOrDefault();
                if(dbEntry != null)
                {
                    dbEntry.Category = course.Category;
                    dbEntry.CourseStartDate = course.CourseStartDate;
                    dbEntry.Details = course.Details;
                    dbEntry.Full = course.Full;
                    dbEntry.Name = course.Name;
                    dbEntry.CourseId = course.CourseId;
                }
            }
            _context.SaveChanges();
        }

        public void SaveCourse(Course course)
        {
            _context.Add(course);
            _context.SaveChanges();
        }
    }
}
