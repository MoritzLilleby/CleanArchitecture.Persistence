using Persistence.Behaviours.Greek;

namespace Persistence.EF.Entities
{
    internal class WeatherForecastEntity
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
