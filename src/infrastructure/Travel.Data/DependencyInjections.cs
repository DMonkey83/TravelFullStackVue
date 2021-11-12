using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travel.Application.Common.Interfaces;
using Travel.Data.Contexts;

namespace Travel.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureData(this IServiceCollection services)
        {

            var connectionString = "server=localhost;user=evilnis;password=Lon19ska83;database=TravelDb";
            var serverVersion = new MariaDbServerVersion(new Version(10, 3, 31));
            services.AddDbContext<ApplicationDbContext>(
                options => options
                .UseMySql(connectionString, serverVersion)
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            );

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            return services;
        }
    }
}