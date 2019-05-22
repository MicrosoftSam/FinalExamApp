using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace FinalExamApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSignUp> CourseSignUps { get; set; }
        public DbSet<News> News { get; set; }
    }
}
