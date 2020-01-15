using System.Linq;
using AVPZCard.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AVPZCard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var scope = host.Services.CreateScope();

            var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            ctx.Database.EnsureCreated();

            var adminrole = new IdentityRole("Admin");
            if (!ctx.Roles.Any())
            {
                roleManager.CreateAsync(adminrole).GetAwaiter().GetResult();
                //create a role
            }

            if (!ctx.Users.Any(u => u.UserName == "admin"))
            {
                var adminUser = new IdentityUser
                {
                    UserName = " ",
                    Email = "admin@test.com"
                };
                var result = userManager.CreateAsync(adminUser, " ").GetAwaiter().GetResult();
                //add role to user
                userManager.AddToRoleAsync(adminUser, adminrole.Name).GetAwaiter().GetResult();
                //create an admin
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
