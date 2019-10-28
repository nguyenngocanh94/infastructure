using Geardao.Deploy.Supervisor.Ef;
using Geardao.Deploy.Supervisor.EventBus;
using Microsoft.Extensions.Logging;

namespace Geardao.Deploy.Supervisor.Service
{
    public class BaseService
    {
        protected readonly SupervisorContext _dbContext;
        protected ILogger<BaseService> _logger;
        protected IEventBus _eventBus;
        protected IHttpContext _httpContext;
        public BaseService(SupervisorContext context, ILogger<BaseService> logger, IEventBus eventBus, IHttpContext httpContext)
        {
            _dbContext = context;
            _logger = logger;
            _eventBus = eventBus;
            _httpContext = httpContext;
        }
    }
}