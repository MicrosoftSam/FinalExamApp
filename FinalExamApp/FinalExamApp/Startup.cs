using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using FinalExamApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FinalExamApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration["Data:FinalExamRepo:ConnectionString"]));
            services.AddTransient<ICourseRepository, EFRepository>();
            services.AddTransient<INewsRepository, EFNewsRepository>();
            services.AddTransient<ICourseSignUp, EFSignUpRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: null,
                        template: "{category}/Page{coursePage:int}",
                        defaults: new { controller = "Course", action = "Index" });

                    routes.MapRoute(
                        name: null,
                        template: "Page{coursePage:int}",
                        defaults: new
                        {
                            controller = "Course",
                            action = "Index",
                            coursePage = 1
                        });

                    routes.MapRoute(
                        name: null,
                        template: "{category}",
                        defaults: new
                        {
                            controller = "Course",
                            action = "Index",
                            coursePage = 1
                        });

                    routes.MapRoute(
                        name: null,
                        template: "",
                        defaults: new
                        {
                            controller = "Home",
                            action = "Index"
                        });

                    routes.MapRoute(
                       name: null,
                       template: "{controller=Home}/{action=Index}/{id?}");
                });
                SeedData.EnsurePopulatedCourses(app);
                SeedData.EnsurePopulatedCourseSignUps(app);
            }
        }
    }
}
