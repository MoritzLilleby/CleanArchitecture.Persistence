using Dapper;
using Application.Contracts;
using Persistence.Dapper.Repositories.Interfaces;

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

        public async Task<List<WeatherForecast>> GetAll()
        {
            var query = "SELECT * FROM WeatherForeCast";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<WeatherForecast>(query);
                return result.ToList();
            }
        }
    }
}
