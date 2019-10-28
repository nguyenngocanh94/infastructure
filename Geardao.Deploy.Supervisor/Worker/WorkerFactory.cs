using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;
using WorkerInDb = Geardao.Deploy.Supervisor.Ef.Model.Worker;

namespace Geardao.Deploy.Supervisor.Worker
{
    public class WorkerFactory
    {
        private IServiceCollection _iocContainer; 
        public WorkerFactory(IServiceCollection serviceDi)
        {
            _iocContainer = serviceDi;
        }
        public WorkerInstance GetWorker(WorkerInDb worker)
        {
            return new WorkerInstance(worker);
        }
    }
}