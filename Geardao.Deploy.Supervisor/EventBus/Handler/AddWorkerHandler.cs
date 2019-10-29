using System;
using System.Threading.Tasks;
using Geardao.Deploy.Supervisor.Worker;
using JKang.EventBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Geardao.Deploy.Supervisor.EventBus.Handler
{
    public class AddWorkerHandler : IEventHandler<Ef.Model.Worker>
    {
        private IServiceProvider  _provider;
        private WorkersPool _workersPool;
        public AddWorkerHandler(WorkersPool workersPool, IServiceProvider  provider)
        {
            _workersPool = workersPool;
            _provider = provider;
        }
        
        public Task HandleEventAsync(Ef.Model.Worker worker)
        {
            if (worker.Maxinstanceinpool == 0 )
            {
                worker.Maxinstanceinpool = 10;
            }

            if (worker.Weight==0)
            {
                worker.Weight = 1;
            }
            
            var workerInit = new WorkerInit(worker, (ILogger<WorkerInit>)_provider.GetService(typeof(ILogger<WorkerInit>)));
            
        }
    }
}