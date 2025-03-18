using Persistence.Behaviours.Greek;

namespace Persistence.EF.Entities
{
    public interface IWeatherForecastEntity
    {
        DateOnly Date { get; }
        Guid Id { get; }
        string? Summary { get; }
        int TemperatureC { get; }
    }

    internal class WeatherForecastEntity : IWeatherForecastEntity
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }


        public void Accept(IWeatherGodVisitor visitor)
        {
            visitor.Visit(this);
        }

    }
}
