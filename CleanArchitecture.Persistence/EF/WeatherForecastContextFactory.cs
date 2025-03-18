using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF
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
