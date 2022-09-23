using PlatformService.Models;
using System.Linq;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                context.Platforms.AddRange(
                    new Platform { Name = "C#", Publisher = "Microsoft", Cost = "Free"},
                    new Platform { Name = "Java", Publisher = "Oracle", Cost = "Free"},
                    new Platform { Name = "Docker", Publisher = "Linux", Cost = "Free"},
                    new Platform { Name = "Sql Server", Publisher = "Microsoft", Cost = "Free"}
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
