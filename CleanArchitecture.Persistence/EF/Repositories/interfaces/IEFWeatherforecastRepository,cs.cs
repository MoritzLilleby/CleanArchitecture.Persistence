using Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF.Repositories.interfaces
{
    public interface IEFWeatherforecastRepository : IWeatherForecastRepository
    {
        Task CreateGreekWeather();
        Task CreateNorseWeather();
    }
}
