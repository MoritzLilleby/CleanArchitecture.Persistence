using Microsoft.EntityFrameworkCore;
using Persistence.Behaviours.Norse;
using Persistence.Creational;
using Persistence.EF.Entities;
using Persistence.EF.Repositories.interfaces;

namespace Persistence.EF.Repositories
{

    internal class WeatherForecastRepository(IWeatherForecastContext context) : IEFWeatherforecastRepository
    {
        private readonly DbSet<WeatherForecastEntity> _table = context.WeatherForcastEntities;

        private WeatherForecastEntity WeatherForecastEntity { get; set; } = new WeatherForecastEntity();

        public async Task CreateGreekWeather()
        {
            var factory = new GreekWeatherGodVisitorFactory();

            WeatherForecastEntity.Accept(factory.CreateRandomWeatherGodVisitor());

            await _table.AddAsync(WeatherForecastEntity);

            await context.SaveChangesAsync();
        }

        public async Task CreateNorseWeather()
        {
            var factory = new NorseWeatherGodVisitorFactory();

            var norseGod = factory.CreateRandomWeatherGodVisitor();

            WeatherForecastEntity.Accept(norseGod);

            var theAllFather = new Odin();
            var ravens = theAllFather.CallRavens();
            ravens.Observe(norseGod);

            await _table.AddAsync(WeatherForecastEntity);

            await context.SaveChangesAsync();
        }

        public async Task<List<IWeatherForecastEntity>> GetAll()
        {
            var result = await _table.Select(s => 
                new WeatherForecastEntity
                {
                    Summary = s.Summary,
                    TemperatureC = s.TemperatureC
                }).ToListAsync<IWeatherForecastEntity>();

            return result;

        }
    }

}
