namespace CleanArchitecture.Persistence.Contracts
{
    internal interface IWeatherGodVisitor
    {
        public void Visit(WeatherForecastEntity weatherForecast);
    }
}
