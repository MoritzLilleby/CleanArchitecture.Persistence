using CleanArchitecture.Persistence.Contracts;

namespace CleanArchitecture.Persistence.Behaviours.Greek
{
    internal class Notus : Anemoi
    {
        public override void Visit(WeatherForecastEntity weatherForecast)
        {
            Console.WriteLine($"Notus is visiting {weatherForecast.Summary} weather on {weatherForecast.Date}.");

            weatherForecast.Summary = "Hot Wind";
            weatherForecast.TemperatureC += 10;
            weatherForecast.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        }
    }

}
