using Dapper;
using Persistence.Dapper.Repositories.Interfaces;
using Persistence.EF.Entities;

namespace Persistence.Dapper.Repositories
{
    public class WeatherForecastRepository(IDapperContext context) : IDPWeatherForecastRepository
    {
        public Task CreateGreekWeather()
        {
            throw new NotImplementedException();
        }

        public Task CreateNorseWeather()
        {
            throw new NotImplementedException();
        }

        public async Task<List<IWeatherForecastEntity>> GetAll()
        {
            var query = "SELECT * FROM WeatherForeCast";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<WeatherForecastEntity>(query);
                return result.ToList<IWeatherForecastEntity>();
            }
        }
    }
}
