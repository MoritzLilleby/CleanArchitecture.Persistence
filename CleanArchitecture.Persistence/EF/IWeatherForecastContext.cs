using CleanArchitecture.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.EF
{
    public interface IWeatherForecastContext
    {
        internal DbSet<WeatherForecastEntity> WeatherForcastEntities { get; }

        internal Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }

}
