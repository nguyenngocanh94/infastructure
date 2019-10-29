using Geardao.Deploy.Supervisor.EventBus;
using Geardao.Deploy.Supervisor.Service;
using Geardao.Deploy.Supervisor.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Geardao.Deploy.Supervisor.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IEventBus, TaskEventBus>();
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContext, HttpContextService>();
            services.AddScoped<IAuth, AuthService>();
            services.AddSingleton<WorkersPool>();
            services.AddScoped<WorkerService>();
            return services;
        }
    }
}