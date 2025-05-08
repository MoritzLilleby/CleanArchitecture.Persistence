using CleanArchitecture.Persistence.Contracts;
namespace CleanArchitecture.Persistence.Behaviours.Greek
{
    internal class Zephyrus : Anemoi
    {
        public override void Visit(WeatherForecastEntity weatherForecast)
        {
            Console.WriteLine($"Zephyrus is visiting {weatherForecast.Summary} weather on {weatherForecast.Date}.");

            weatherForecast.Summary = "Mild Breeze";
            weatherForecast.TemperatureC += 5;
            weatherForecast.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        }
    }

}
