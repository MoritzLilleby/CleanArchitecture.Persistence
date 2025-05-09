using CleanArchitecture.Persistence.Contracts;
using CleanArchitecture.Persistence.Dapper;
using CleanArchitecture.Persistence.Dapper.Repositories;

namespace CleanArchitecture.Persistence.IntegrationTest
{
    [TestFixture]
    public class DapperWeatherForecastRepositoryTests
    {
        private WeatherForecastRepository _repository;

        [SetUp]
        public void Setup()
        {
            var dapperContext = new DapperContext("Server=localhost;Database=GodWeatherForcast;Trusted_Connection=True;MultipleActiveResultSets=true; Encrypt=false");

            _repository = new WeatherForecastRepository(dapperContext);
        }

        [Test]
        public async Task CreateGreekWeather_ShouldInsertData()
        {
            // Act
            await _repository.CreateGreekWeather();
        }

        [Test]
        public async Task CreateNorseWeather_ShouldInsertData()
        {
            // Act
            await _repository.CreateNorseWeather();
        }

        [Test]
        public async Task GetAll_ShouldReturnListOfWeatherForecastEntities()
        {
            // Arrange
            var k = new WeatherForecastEntity { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 25, Summary = "SunnyTest" };
            k.CreateId();
            var k1 = new WeatherForecastEntity { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), TemperatureC = 20, Summary = "CloudyTest" };
            k1.CreateId();

            // Arrange
            var mockList = new List<IWeatherForecastEntity>()
            {
                k,
                k1
            };


            // Act
            var result = await _repository.GetAll();

            // Assert
            Assert.That(result, Is.Not.Null); // Updated assertion
            Assert.That(result.Count, Is.EqualTo(2)); // Updated assertion
            Assert.That(result[0].Summary, Is.EqualTo("Sunny")); // Updated assertion
        }

        [Test]
        public async Task InsertOrUpdateList_ShouldCallStoredProcedure()
        {
            var k = new WeatherForecastEntity { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 25, Summary = "SunnyTest" };
            k.CreateId();
            var k1 = new WeatherForecastEntity { Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), TemperatureC = 20, Summary = "CloudyTest" };
            k1.CreateId();

            // Arrange
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
