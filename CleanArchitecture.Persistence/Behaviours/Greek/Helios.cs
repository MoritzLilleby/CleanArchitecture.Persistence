using CleanArchitecture.Persistence.Contracts;

namespace CleanArchitecture.Persistence.Behaviours.Greek
{
    internal class Helios : IWeatherGodVisitor
    {
        public void Visit(WeatherForecastEntity weatherForecast)
        {
            Console.WriteLine($"Helios is visiting {weatherForecast.Summary} weather on {weatherForecast.Date}.");

            weatherForecast.Summary = "Sunny";
            weatherForecast.TemperatureC = 35;
            weatherForecast.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        }

    }

}
