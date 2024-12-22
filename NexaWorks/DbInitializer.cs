using NexaWorks.Data;
using Microsoft.EntityFrameworkCore;

namespace NexaWorks
{
    public static class DbInitializer
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {/**/
                var context = services.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
                SeedData.Initialize(services);
            }
            catch (DbUpdateException dbEx)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError($"Erreur lors de la mise à jour de la base de données : {dbEx.Message}");

                if (dbEx.InnerException != null)
                {
                    logger.LogError($"Détails supplémentaires : {dbEx.InnerException.Message}");
                }
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB. ");
            }/**/

            return app;
        }
    }
}
