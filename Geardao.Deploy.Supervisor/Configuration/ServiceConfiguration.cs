using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Geardao.Deploy.Supervisor.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureService(this IServiceCollection services,
            IConfiguration configuration)
        {
            
            return services;
        }
    }
}