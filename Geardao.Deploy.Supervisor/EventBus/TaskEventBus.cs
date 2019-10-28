using System;
using JKang.EventBus;

namespace Geardao.Deploy.Supervisor.EventBus
{
    public class TaskEventBus : IEventBus
    {
        private readonly IEventPublisher _eventPublisher;

        public TaskEventBus(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }
        
        public void Fire(object message)
        {
            _eventPublisher.PublishEventAsync(message);
        }
    }
    
    
    public interface IEventBus
    {
        void Fire(Object message);
    }
}