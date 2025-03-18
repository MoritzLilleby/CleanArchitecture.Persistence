using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF.EntityTypeConfigurations
{
    internal class WeatherForecastTypeConfiguration : IEntityTypeConfiguration<WeatherForecastEntity>
    {
        public void Configure(EntityTypeBuilder<WeatherForecastEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(p => p.Date)
                .IsRequired();

            builder
             .Property(p => p.TemperatureC).HasMaxLength(50)
             .IsRequired();

            builder
                .Property(p => p.Summary)
                .IsRequired(false)
                .HasMaxLength(150);

            builder.ToTable("WeatherForecast");
        }
    }
}
