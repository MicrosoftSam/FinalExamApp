using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamApp.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "BigBoss_123";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole("Admin");
                await roleManager.CreateAsync(role);

                IdentityUser user = await userManager.FindByIdAsync(adminUser);
                if (user == null)
                {
                    user = new IdentityUser("Admin");
                    IdentityResult chkUser = await userManager.CreateAsync(user, adminPassword);

                    if (chkUser.Succeeded)
                    {
                        IdentityResult userResult = await userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }

            if (!await roleManager.RoleExistsAsync("Employee"))
            {
                var role = new IdentityRole("Employee");
                await roleManager.CreateAsync(role);
            }

            if(!await roleManager.RoleExistsAsync("User"))
            {
                var role = new IdentityRole("User");
                await roleManager.CreateAsync(role);
            }
        }
    }
}
