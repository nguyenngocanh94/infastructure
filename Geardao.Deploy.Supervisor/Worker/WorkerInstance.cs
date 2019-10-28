using Geardao.Deploy.Supervisor.Ef;
using Microsoft.Extensions.Logging;
using Renci.SshNet;
using WorkerDb = Geardao.Deploy.Supervisor.Ef.Model.Worker;

namespace Geardao.Deploy.Supervisor.Worker
{
    public class WorkerInstance
    {
        public WorkerDb Worker { get; private set; }
        private SupervisorContext _dbContext;
        private ILogger<WorkerInstance> _logger;
        
        public WorkerInstance(WorkerDb worker, SupervisorContext dbContext, ILogger<WorkerInstance> logger)
        {
            Worker = worker;
            _logger = logger;
            _dbContext = dbContext;
        }


        public bool SetUpClient()
        {
            return true;
        }

        public ConnectionInfo GetSshConnection()
        {
           return  new ConnectionInfo(Worker.Ip, Worker.Username,
                new PasswordAuthenticationMethod(Worker.Username, Worker.Password));
        }
    }
}