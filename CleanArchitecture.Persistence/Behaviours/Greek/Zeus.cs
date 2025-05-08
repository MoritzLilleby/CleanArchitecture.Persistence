using CleanArchitecture.Persistence.Contracts;

namespace CleanArchitecture.Persistence.Behaviours.Greek
{
    internal class Zeus : IWeatherGodVisitor
    {
        public void Visit(WeatherForecastEntity weatherForecast)
        {
            Console.WriteLine($"Zeus is visiting {weatherForecast.Summary} weather on {weatherForecast.Date}.");

            weatherForecast.Summary = "Thunderstorm";
            weatherForecast.TemperatureC = 30;
            weatherForecast.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        }
    }
}
