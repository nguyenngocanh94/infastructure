using System.Data.Common;
using Geardao.Deploy.Supervisor.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Geardao.Deploy.Supervisor.Configuration
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDatabaseContext>(
                option => { option.UseSqlite(configuration["ConnectionStrings"]); });

            return services;
        }
        
    }
}