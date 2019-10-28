using Geardao.Deploy.Supervisor.Ef;
using Geardao.Deploy.Supervisor.EventBus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Geardao.Deploy.Supervisor.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ILogger<BaseController> _logger;
        protected SupervisorContext _dbContext;
        
        public BaseController(SupervisorContext supervisorContext, ILogger<BaseController> logger)
        {
            _dbContext = supervisorContext;
            _logger = logger;
        }

        public BaseController()
        {
            
        }
    }
}