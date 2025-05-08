using CleanArchitecture.Persistence.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Persistence.EF
{
    public class DbInitializer
    {
        protected DbInitializer()
        {
        }

        public static void CreateDbIfNotExists(IServiceProvider services)
        {

            try
            {

                var context = services.GetRequiredService<WeatherForecastContext>();

                var weatherForcastTable = context.Set<WeatherForecastEntity>();

                // Look for any weathergods.
                if (weatherForcastTable.Any())
                {
                    return;   // DB has been seeded
                }

                string[] Summaries = new[]
                {
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                };

                var forcasts = Enumerable.Range(1, 5).Select(index => new WeatherForecastEntity
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray();

                weatherForcastTable.AddRange(forcasts);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<DbInitializer>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }


    }
}
