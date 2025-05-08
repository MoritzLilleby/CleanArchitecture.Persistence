using CleanArchitecture.Persistence.Contracts;

namespace CleanArchitecture.Persistence.Behaviours.Miscellaneous
{
    internal class FrogGod : IWeatherGodVisitor
    {
        public void Visit(WeatherForecastEntity weatherForecast)
        {
            weatherForecast.Summary = "Raining frogs";
        }
    }
}
