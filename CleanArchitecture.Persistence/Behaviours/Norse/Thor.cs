using Persistence.Behaviours.Greek;
using Persistence.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Behaviours.Norse
{
    internal class Thor : IWeatherGodVisitor
    {
        public void Visit(WeatherForecastEntity weatherForecast)
        {
            weatherForecast.Summary = "Thunderstorm";
            weatherForecast.TemperatureC = 30;
            weatherForecast.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        }
    }
}
