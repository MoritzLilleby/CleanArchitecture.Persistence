using CleanArchitecture.Persistence.ADO.NET_SQL.Repositories.Interfaces;
using CleanArchitecture.Persistence.Contracts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.ADO.NET_SQL.Repositories
{
    internal class WeatherForecastRepository : IAdoWeatherForecastRepository
    {

        public WeatherForecastRepository(AdoWeatherForecastContext context) 
        {
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
            // Define the connection string
            string connectionString = "your_connection_string_here";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // Create a temporary table to hold the data
                string createTempTableQuery = @"
                CREATE TABLE #TempWeatherForecast (
                    Id UNIQUEIDENTIFIER,
                    Date DATETIME,
                    TemperatureC INT,
                    Summary NVARCHAR(MAX)
                )";

                using (SqlCommand createTempTableCmd = new SqlCommand(createTempTableQuery, connection))
                {
                    await createTempTableCmd.ExecuteNonQueryAsync();
                }

                // Insert data into the temporary table
                foreach (var item in myList)
                {
                    string insertQuery = @"
                    INSERT INTO #TempWeatherForecast (Id, Date, TemperatureC, Summary)
                    VALUES (@Id, @Date, @TemperatureC, @Summary)";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@Id", item.Id);
                        insertCmd.Parameters.AddWithValue("@Date", item.Date.ToDateTime(TimeOnly.MinValue)); // Convert DateOnly to DateTime
                        insertCmd.Parameters.AddWithValue("@TemperatureC", item.TemperatureC);
                        insertCmd.Parameters.AddWithValue("@Summary", item.Summary);

                        await insertCmd.ExecuteNonQueryAsync();
                    }
                }

                // Execute the stored procedure using the temporary table
                string execStoredProcedureQuery = "EXEC dbo.UpdateWeatherGodForecast @MyObjects = #TempWeatherForecast";
                using (SqlCommand execStoredProcedureCmd = new SqlCommand(execStoredProcedureQuery, connection))
                {
                    await execStoredProcedureCmd.ExecuteNonQueryAsync();
                }

                // Close the connection
                await connection.CloseAsync();
            }
        }

    }
}
