using CleanArchitecture.Persistence.Contracts;

namespace CleanArchitecture.Persistence.Behaviours.Greek
{
    internal abstract class Anemoi : IWeatherGodVisitor, IAnemoi
    {
        public abstract void Visit(WeatherForecastEntity weatherForecast);
    }

}
