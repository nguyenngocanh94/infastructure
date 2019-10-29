//using Geardao.Deploy.Supervisor.Ef;

using Geardao.Deploy.Supervisor.Ef;
using Geardao.Deploy.Supervisor.EventBus;
using Microsoft.Extensions.Logging;

namespace Geardao.Deploy.Supervisor.Service
{
    public class WorkerService : BaseService
    {
        public WorkerService(SupervisorContext context, ILogger<BaseService> logger, IEventBus eventBus, IHttpContext httpContext) : base(context, logger, eventBus, httpContext)
        {
        }

        public void Add(Ef.Model.Worker worker)
        {
            _dbContext.Worker.Add(worker);
            _eventBus.Fire(worker);
        }
    }
}