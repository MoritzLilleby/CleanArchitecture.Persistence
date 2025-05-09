using CleanArchitecture.Persistence.ADO.NET_SQL;
using CleanArchitecture.Persistence.ADO.NET_SQL.Repositories;
using CleanArchitecture.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.IntegrationTest
{
    [TestFixture]
    public class AdoWeatherForecastRepositoryTest
    {
        private WeatherForecastRepository _repository;

        [SetUp]
        public void Setup()
        {
            // Initialize any required resources or dependencies here

            var adoContext = new AdoContext("Server=localhost;Database=GodWeatherForcast;Trusted_Connection=True;MultipleActiveResultSets=true; Encrypt=false");

            _repository = new WeatherForecastRepository(adoContext);

        }

        [Test]
        public async Task InsertOrUpdateList_ShouldCallStoredProcedure()
        {

            // Arrange

            var k = new WeatherForecastEntity { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 25, Summary = "SunnyTest" };
            k.CreateId();
            var k1 = new WeatherForecastEntity { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), TemperatureC = 20, Summary = "CloudyTest" };
            k1.CreateId();

            var mockList = new List<IWeatherForecastEntity>()
            {
                k,
                k1
            };

            // Act
            await _repository.InsertOrUpdateList(mockList);


        }




    }
}
