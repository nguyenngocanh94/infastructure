using Geardao.Deploy.Supervisor.Ef;
using Geardao.Deploy.Supervisor.Ef.Model;
using Geardao.Deploy.Supervisor.EventBus;
using Microsoft.Extensions.Logging;

namespace Geardao.Deploy.Supervisor.Service
{
    public class DeployService : BaseService
    {
        public DeployService(SupervisorContext context, ILogger<BaseService> logger, IEventBus eventBus, IHttpContext httpContext) : base(context, logger, eventBus, httpContext)
        {
        }

        public void Register(Task task)
        {
            _dbContext.Task.Add(task);
            
        }
    }
}