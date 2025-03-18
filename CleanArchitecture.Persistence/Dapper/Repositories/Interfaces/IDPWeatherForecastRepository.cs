using Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Dapper.Repositories.Interfaces
{
    public interface IDPWeatherForecastRepository : IWeatherForecastRepository
    {
        Task CreateGreekWeather();
        Task CreateNorseWeather();
    }
}
