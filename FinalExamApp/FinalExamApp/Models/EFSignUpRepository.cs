using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamApp.Models
{
    public class EFSignUpRepository : ICourseSignUp
    {
        private ApplicationDbContext _context;

        public EFSignUpRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<CourseSignUp> CourseSignUps => _context.CourseSignUps;

        public void SaveSignUp(CourseSignUp signUp, int id)
        {
            signUp.CourseId = id;
            _context.Add(signUp);
            _context.SaveChanges();
        }
    }
}
