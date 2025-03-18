using Persistence.Behaviours.Greek;
using Persistence.Behaviours.Norse.Observers;
using Persistence.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Behaviours.Norse
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
