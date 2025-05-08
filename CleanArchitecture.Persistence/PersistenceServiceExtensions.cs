using CleanArchitecture.Persistence.Dapper;
using CleanArchitecture.Persistence.Dapper.Extensions;
using CleanArchitecture.Persistence.Dapper.Repositories.Interfaces;
using CleanArchitecture.Persistence.EF;
using CleanArchitecture.Persistence.EF.Repositories.interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence
{
    public static class PersistenceServiceExtensions
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConnectionString = configuration.GetConnectionString("DefaultConnection");

            // EF CORE
            services.AddDbContext<IWeatherForecastContext, WeatherForecastContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);
            });

            services.AddScoped<IEFWeatherforecastRepository, EF.Repositories.WeatherForecastRepository>();


            // DAPPER CORE
            services.AddSingleton<IDapperContext, DapperContext>(provider =>
            {
                return new DapperContext(sqlConnectionString!);
            });

            // Register the custom type handler
            SqlMapper.AddTypeHandler(new DapperDateOnlyTypeHandler());

            services.AddScoped<IDPWeatherForecastRepository, Dapper.Repositories.WeatherForecastRepository>();


        }

    }
}
