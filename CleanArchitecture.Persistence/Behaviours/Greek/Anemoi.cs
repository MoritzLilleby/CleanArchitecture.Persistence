using Persistence.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Behaviours.Greek
{
    internal abstract class Anemoi : IWeatherGodVisitor, IAnemoi
    {
        public abstract void Visit(WeatherForecastEntity weatherForecast);
    }

}
