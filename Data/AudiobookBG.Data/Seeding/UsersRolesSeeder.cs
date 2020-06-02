namespace AudiobookBG.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AudiobookBG.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class UsersRolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedUserRoleAsync(userManager, roleManager, dbContext);
        }

        private static async Task SeedUserRoleAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ApplicationDbContext dbContext)
        {
            if (dbContext.UserRoles.Any() || !dbContext.Users.Any())
            {
                return;
            }
            else
            {
                var user = userManager.Users.FirstOrDefault();
                var role = await roleManager.FindByNameAsync("Administrator");

                await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
                {
                    RoleId = role.Id,
                    UserId = user.Id,
                });
            }
        }
    }
}
