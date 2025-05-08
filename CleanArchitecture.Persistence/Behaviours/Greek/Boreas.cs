using CleanArchitecture.Persistence.Contracts;

namespace CleanArchitecture.Persistence.Behaviours.Greek
{
    internal class Boreas : Anemoi
    {
        public override void Visit(WeatherForecastEntity weatherForecast)
        {
            Console.WriteLine($"Boreas is visiting {weatherForecast.Summary} weather on {weatherForecast.Date}.");

            weatherForecast.Summary = "Cold Wind";
            weatherForecast.TemperatureC -= 10;
            weatherForecast.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        }
    }

}
