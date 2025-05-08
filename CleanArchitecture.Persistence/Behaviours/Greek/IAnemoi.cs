using CleanArchitecture.Persistence.Contracts;

namespace CleanArchitecture.Persistence.Behaviours.Greek
{
    internal interface IAnemoi
    {
        void Visit(WeatherForecastEntity weatherForecast);
    }
}