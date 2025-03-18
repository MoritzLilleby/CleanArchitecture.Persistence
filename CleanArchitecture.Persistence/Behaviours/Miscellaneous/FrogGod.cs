using Persistence.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Behaviours.Miscellaneous
{
    internal class FrogGod : IWeatherFrogGodVisitor
    {
        public void Visit(WeatherForecastEntity weatherForecast)
        {
            weatherForecast.Summary = "Raining frogs";
        }
    }
}
