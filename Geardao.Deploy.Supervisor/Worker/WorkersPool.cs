using System.Buffers;
using System.Collections.Concurrent;
using System.Linq;
using Geardao.Deploy.Supervisor.Ef;
using Microsoft.Extensions.Logging;

namespace Geardao.Deploy.Supervisor.Worker
{
    public class WorkersPool
    {
        private ConcurrentBag<WorkerInstance> WorkerPool { get; }
        private int counter;
        private ILogger<WorkersPool> _logger;
        private static readonly object _look = new object();  
        private WorkersPool(ILogger<WorkersPool> logger)
        {
            _logger = logger;
            WorkerPool = new ConcurrentBag<WorkerInstance>();
        }
        
        public void SetWorkerInPool(WorkerInstance workerInstance)
        {
            if (WorkerPool.Contains(workerInstance))
            {
                return;
            }
            
            WorkerPool.Add(workerInstance);
            counter ++;
        }

        public WorkerInstance Get(Ef.Model.Worker worker)
        {
            return WorkerPool.FirstOrDefault(w => w.Worker.Id == worker.Id);
            counter--;
        }

    }
}