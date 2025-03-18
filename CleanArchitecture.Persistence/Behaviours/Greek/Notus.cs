using Persistence.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Behaviours.Greek
{
    internal class Notus : Anemoi
    {
        public override void Visit(WeatherForecastEntity weatherForecast)
        {
            Console.WriteLine($"Notus is visiting {weatherForecast.Summary} weather on {weatherForecast.Date}.");

            weatherForecast.Summary = "Hot Wind";
            weatherForecast.TemperatureC += 10;
            weatherForecast.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        }
    }

}
