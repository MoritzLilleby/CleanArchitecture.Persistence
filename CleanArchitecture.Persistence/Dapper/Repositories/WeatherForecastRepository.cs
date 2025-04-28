using Dapper;
using Persistence.Creational;
using Persistence.Dapper.Repositories.Interfaces;
using Persistence.EF.Entities;

namespace Persistence.Dapper.Repositories
{
    public class WeatherForecastRepository(IDapperContext context) : IDPWeatherForecastRepository
    {
        public Task CreateGreekWeather()
        {

            var table = new WeatherForecastEntity();
            table.CreateId();

            var factory = new GreekWeatherGodVisitorFactory();
            var greekGod = factory.CreateRandomWeatherGodVisitor();

            table.Accept(greekGod);

            var insert = "INSERT INTO WeatherForecast(Id, Date, TemperatureC, Summary) " +
             "VALUES(@Id, @Date, @TemperatureC, @Summary)";

            using (var connection = context.CreateConnection())
            {
                connection.Execute(insert, table);
            }

            return Task.CompletedTask;
        }

        public Task CreateNorseWeather()
        {

            var table = new WeatherForecastEntity();
            table.CreateId();
            //Same file?

            var factory = new NorseWeatherGodVisitorFactory();
            var norseGod = factory.CreateRandomWeatherGodVisitor();

            table.Accept(norseGod);

            //var theAllFather = new Odin();
            //var ravens = theAllFather.CallRavens();
            //ravens.Observe(norseGod);

            //Here we are using the same table as in CreateGreekWeather

            var insert = "INSERT INTO WeatherForecast(Id, Date, TemperatureC, Summary) " +
             "VALUES(@Id, @Date, @TemperatureC, @Summary)";

            using (var connection = context.CreateConnection())
            {
                connection.Execute(insert, table);
            }

            return Task.CompletedTask;

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
