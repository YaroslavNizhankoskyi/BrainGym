using BrainGym.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BrainGym.WebAPI.Helpers.Seed
{
    public static class MigrateDbExtension
    {
        public async static Task<WebApplication> MigrateDb(this WebApplication app)
        {
            try
            {
                using (var scope = app.Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    dbContext.Database.Migrate();
                }

                await app.SeedIdentity();
            }
            catch (Exception ex)
            {
                var logger = app.Services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Ann error occured during migrations");
            }

            return app;
        }
    }

}
