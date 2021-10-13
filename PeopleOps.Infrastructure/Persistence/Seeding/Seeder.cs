using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using PeopleOps.Domain.Entities;
using PeopleOps.Domain.Enums;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Seeding
{
    public class Seeder
    {
        public static async Task SeedUsers(UserManager<Employee> userManager)
        {
            // Create seed users
            var seedUser = new Employee
            {
                FirstName = "Admin",
                LastName = "Officer",
                UserName = "admin@peopleops.com",
                Email = "admin@peopleops.com",
                EmailConfirmed = true
            };
            
            if ((await userManager.FindByNameAsync(seedUser.UserName)) == null)
            {
                var result = await userManager.CreateAsync(seedUser, "P@ssw0rd");
                if (result.Succeeded)
                {
                    var newUser = userManager.FindByNameAsync(seedUser.UserName).Result;
                    await userManager.AddToRolesAsync(newUser, new[] { RoleTypes.Admin.ToString() });
                }
            }
        }

        public static async Task SeedUsersFromJson(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            var json = File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<Employee>>(json);

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "P@ssw0rd");
                await userManager.AddToRoleAsync(user, "Member");
            }
        }

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            var roles = new List<IdentityRole>{
                new IdentityRole{ Name = RoleTypes.Admin.ToString()},
                new IdentityRole{ Name = RoleTypes.HOD.ToString()},
                new IdentityRole{ Name = RoleTypes.Employee.ToString()},
            };

            foreach (var role in roles)
            {
                if (!(await roleManager.RoleExistsAsync(role.Name)))
                {
                    await roleManager.CreateAsync(role);
                    /*await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, "projects.view"));
                    await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, "projects.create"));
                    await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, "projects.update"));*/
                }
            }
        }

        private static IEnumerable<Employee> GetPreconfiguredUsers()
        {
            return new List<Employee>
            {
                new Employee
                {
                    UserName = "Admin",
                    Email = "theophilusighalo@gmail.com",
                    EmailConfirmed = true
                }
            };
        }
    }
}
