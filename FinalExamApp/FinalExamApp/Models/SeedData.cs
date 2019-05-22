using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamApp.Models
{
    public class SeedData
    {
        public static void EnsurePopulatedCourses(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course
                    {
                        Name = "C++ course",
                        Details = "Learn c++ the hard way",
                        Full = false
                    },
                    new Course
                    {
                        Name = "C# course",
                        Details = "Learn c# the hard way",
                        Full = false
                    },
                    new Course
                    {
                        Name = "PHP course",
                        Details = "Learn PHP the hard way",
                        Full = false
                    }
                    );
                context.SaveChanges();
            }
        }

        public static void EnsurePopulatedCourseSignUps(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.CourseSignUps.Any())
            {
                context.CourseSignUps.AddRange(
                    new CourseSignUp
                    {
                        FirstName = "Tena",
                        LastName = "Novak",
                        Address = "Antuna Štrbana 16"
                    },
                    new CourseSignUp
                    {
                        FirstName = "Ema",
                        LastName = "Novak",
                        Address = "Antuna Štrbana 18"
                    },
                    new CourseSignUp
                    {
                        FirstName = "Xena",
                        LastName = "Novak",
                        Address = "Antuna Štrbana 19"
                    },
                    new CourseSignUp
                    {
                        FirstName = "Arya",
                        LastName = "Novak",
                        Address = "Antuna Štrbana 20"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
