/*using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Seeding
{
    public class ApplicationDbContextSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext dataDbContext, ILogger<ApplicationDbContextSeeder> logger)
        {
            if (!dataDbContext.Permissions.Any())
            {
                dataDbContext.Permissions.AddRange(GetPreconfiguredPermissions());
                await dataDbContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ApplicationDbContext).Name);
            }
        }

        private static IEnumerable<Permission> GetPreconfiguredPermissions()
        {
            return new List<Permission>
            {
                new Permission() { }
            };
        }
    }
}
*/