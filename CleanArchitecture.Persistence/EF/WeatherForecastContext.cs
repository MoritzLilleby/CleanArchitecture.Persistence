using CleanArchitecture.Persistence.Contracts;
using CleanArchitecture.Persistence.EF.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.EF
{
    internal sealed class WeatherForecastContext : DbContext, IWeatherForecastContext
    {
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options)
          : base(options) // Pass options to the base constructor
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new WeatherForecastTypeConfiguration().Configure(modelBuilder.Entity<WeatherForecastEntity>());
        }

        public DbSet<WeatherForecastEntity> WeatherForcastEntities { get; set; }

    }
}
