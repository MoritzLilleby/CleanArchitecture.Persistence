using CleanArchitecture.Persistence.Contracts;
using CleanArchitecture.Persistence.Creational;
using CleanArchitecture.Persistence.Dapper.Extensions;
using CleanArchitecture.Persistence.Dapper.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace CleanArchitecture.Persistence.Dapper.Repositories
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


        public void InsertOrUpdateList(IEnumerable<IWeatherForecastEntity> myList)
        {
            using (var connection = context.CreateConnection())
            {
                var dt = new DataTable();
                dt.Columns.Add("Id", typeof(Guid));
                dt.Columns.Add("Date", typeof(DateTime)); // Changed from DateOnly to DateTime
                dt.Columns.Add("TemperatureC", typeof(int));
                dt.Columns.Add("Summary", typeof(string));

                foreach (var item in myList)
                {
                    dt.Rows.Add(item.Id, item.Date.ToDateTime(TimeOnly.MinValue), item.TemperatureC, item.Summary); // Convert DateOnly to DateTime
                }

                var parameters = new DynamicParameters();
                parameters.Add("@MyObjects", dt.AsTableValuedParameter("dbo.WeatherForecastType"));

                connection.Execute("dbo.UpdateWeatherGodForecast", parameters, commandType: CommandType.StoredProcedure);
            }
        }




    }
}
