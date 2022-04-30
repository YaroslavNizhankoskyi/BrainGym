using BrainGym.Application.Common.Constants;
using BrainGym.Domain;
using BrainGym.Infrastructure.Data.Context;
using BrainGym.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace BrainGym.WebAPI.Helpers.Seed
{
    public static class IdentityDbContextSeed
    {
        private const string Email = "seed-test@gmail.com";
        private const string Password = "Password1*";

        public static async Task<WebApplication> SeedIdentity(this WebApplication app)
        {
            var appUser = new AppUser()
            {
                Email = Email,
                UserName = Email
            };

            var user = new User
            {
                FirstName = "SeedFirstName",
                SecondName = "SeedSecondName",
            };

            try
            {
                using var scope = app.Services.CreateScope();

                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                if (!await roleManager.RoleExistsAsync(RoleConstants.Administrator))
                    await roleManager.CreateAsync(new IdentityRole { Name = RoleConstants.Administrator });
                if (!await roleManager.RoleExistsAsync(RoleConstants.User))
                    await roleManager.CreateAsync(new IdentityRole { Name = RoleConstants.User });

                await userManager.CreateAsync(appUser, Password);

                user.UserId = appUser.Id;

                context.Users.Add(user);

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = app.Services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Ann error occured during seed");
            }

            return app;
        }

    }
}