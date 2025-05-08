using CleanArchitecture.Persistence.Contracts;
namespace CleanArchitecture.Persistence.Behaviours.Greek
{
    internal class Eurus : Anemoi
    {
        public override void Visit(WeatherForecastEntity weatherForecast)
        {
            Console.WriteLine($"Eurus is visiting {weatherForecast.Summary} weather on {weatherForecast.Date}.");

            weatherForecast.Summary = "Stormy Wind";
            weatherForecast.TemperatureC -= 5;
            weatherForecast.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        }
    }

}
