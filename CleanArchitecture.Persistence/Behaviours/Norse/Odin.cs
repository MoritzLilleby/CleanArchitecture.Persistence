using CleanArchitecture.Persistence.Behaviours.Norse.Observers;
using CleanArchitecture.Persistence.Contracts;

namespace CleanArchitecture.Persistence.Behaviours.Norse
{
    internal class Odin : IWeatherGodVisitor, IObserver<IWeatherGodVisitor>
    {

        public Odin()
        {
        }

        public OdinRavens CallRavens()
        {
            var observer = new OdinRavens();
            observer.Subscribe(this);
            return observer;
        }

        public void OnCompleted() { }

        public void OnError(Exception error) { }

        public void OnNext(IWeatherGodVisitor value)
        {
            Console.WriteLine($"Odin is observing {value}.");
        }

        public void Visit(WeatherForecastEntity weatherForecast)
        {
            weatherForecast.Summary = "Windy";
        }

    }
}
