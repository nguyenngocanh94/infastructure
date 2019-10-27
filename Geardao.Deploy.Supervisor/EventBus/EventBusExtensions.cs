using System;
using JKang.EventBus.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Geardao.Deploy.Supervisor.EventBus
{
    public static class EventBusExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services,
            Action<IEventBusBuilder> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            IEventBusBuilder builder = new EventBusBuilder(services);

            setupAction?.Invoke(builder);

            return services;
        }
    }
}
