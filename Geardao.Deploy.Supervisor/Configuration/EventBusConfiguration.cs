using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Geardao.Deploy.Supervisor.Configuration
{
    public static class EventBusConfiguration
    {
        public static IServiceCollection ConfigureEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            EventBusServiceCollectionExtensions.AddEventBus(services, builder=>
            {
                builder.AddInMemoryEventBus(subscriber=>
                {
                    // todo add event handler when catch a event
                });
            });

            return services;
        }
        
    }
}