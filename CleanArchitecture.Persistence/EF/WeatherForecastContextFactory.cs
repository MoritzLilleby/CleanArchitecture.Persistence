using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArchitecture.Persistence.EF
{
    internal class WeatherForecastContextFactory : IDesignTimeDbContextFactory<WeatherForecastContext>
    {
        public WeatherForecastContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherForecastContext>();
            var connectionString = "Server=localhost;Database=GodWeatherForcast;Trusted_Connection=True;MultipleActiveResultSets=true; Encrypt=false";
            optionsBuilder.UseSqlServer(connectionString);

            return new WeatherForecastContext(optionsBuilder.Options);

        }
    }
}
