using CleanArchitecture.Persistence.ADO.NET_SQL.Repositories.Interfaces;
using CleanArchitecture.Persistence.Contracts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.ADO.NET_SQL.Repositories
{
    internal class WeatherForecastRepository : IAdoWeatherForecastRepository
    {
        private AdoContext _context;

        public WeatherForecastRepository(AdoContext context) 
        {
            _context = context;
        }

        public Task CreateGreekWeather()
        {
            throw new NotImplementedException();
        }

        public Task CreateNorseWeather()
        {
            throw new NotImplementedException();
        }

        public Task<List<IWeatherForecastEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task InsertOrUpdateList(IEnumerable<IWeatherForecastEntity> myList)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.OpenAsync();

                // Create a DataTable to hold the data
                var dt = new DataTable();
                dt.Columns.Add("Id", typeof(Guid));
                dt.Columns.Add("Date", typeof(DateTime)); // Changed from DateOnly to DateTime
                dt.Columns.Add("TemperatureC", typeof(int));
                dt.Columns.Add("Summary", typeof(string));

                foreach (var item in myList)
                {
                    dt.Rows.Add(item.Id, item.Date.ToDateTime(TimeOnly.MinValue), item.TemperatureC, item.Summary); // Convert DateOnly to DateTime
                }

                // Create a SqlParameter for the table-valued parameter
                var tableValuedParam = new SqlParameter
                {
                    ParameterName = "@MyObjects",
                    SqlDbType = SqlDbType.Structured,
                    TypeName = "dbo.WeatherForecastType",
                    Value = dt
                };

                // Execute the stored procedure using the table-valued parameter
                using (SqlCommand cmd = new SqlCommand("dbo.UpdateWeatherGodForecast", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(tableValuedParam);

                    await cmd.ExecuteNonQueryAsync();
                }

                // Close the connection
                await connection.CloseAsync();
            }
        }


    }
}
