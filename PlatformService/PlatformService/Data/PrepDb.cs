using Microsoft.EntityFrameworkCore;
using PlatformService.Models;
using System.Linq;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attemptimg to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Couldn't run migrations: {ex.Message}");
                }
            }
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
