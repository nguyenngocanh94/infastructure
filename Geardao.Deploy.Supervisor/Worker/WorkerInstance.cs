using Geardao.Deploy.Supervisor.Ef;
using Geardao.Deploy.Supervisor.Socket;

namespace Geardao.Deploy.Supervisor.Worker
{
    public class WorkerInstance
    {
        private SupervisorContext _dbContext;
        public Ef.Model.Worker Worker { get; set; }
        public Session SocketSesson { get; private set; }
        public WorkerInstance(SupervisorContext dbContext, Ef.Model.Worker worker, Session socketSesson)
        {
            _dbContext = dbContext;
            Worker = worker;
            SocketSesson = socketSesson;
        }
    }
}