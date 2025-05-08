using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("CleanArchitecture.Persistence.IntegrationTest")]
namespace CleanArchitecture.Persistence.Contracts
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
        public Guid Id { get; private set; }
        public DateOnly Date { get; internal set; }

        public int TemperatureC { get; set; }
        public string? Summary { get; set; }

        public void SetId(Guid _Id)
        {
            Id = _Id;
        }

        public void CreateId()
        {
            Id = Guid.NewGuid();
        }

        public void Accept(IWeatherGodVisitor visitor)
        {
            visitor.Visit(this);
        }

    }



}
