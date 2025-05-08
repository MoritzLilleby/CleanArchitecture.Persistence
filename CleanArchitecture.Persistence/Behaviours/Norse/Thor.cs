using CleanArchitecture.Persistence.Contracts;

namespace CleanArchitecture.Persistence.Behaviours.Norse
{
    internal class Thor : IWeatherGodVisitor
    {
        public void Visit(WeatherForecastEntity weatherForecast)
        {
            weatherForecast.Summary = "Thunderstorm";
            weatherForecast.TemperatureC = 30;
            weatherForecast.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        }
    }
}
