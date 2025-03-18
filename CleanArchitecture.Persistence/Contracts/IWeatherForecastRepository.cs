﻿using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contracts
{
    public interface IWeatherForecastRepository
    {
        Task<List<WeatherForecast>> GetAll();
    }
}
