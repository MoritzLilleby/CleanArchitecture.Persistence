using Microsoft.EntityFrameworkCore;
using Persistence.EF.Entities;

namespace Persistence.EF
{
    public interface IWeatherForecastContext
    {
        internal DbSet<WeatherForecastEntity> WeatherForcastEntities { get; }

        internal Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }

}
