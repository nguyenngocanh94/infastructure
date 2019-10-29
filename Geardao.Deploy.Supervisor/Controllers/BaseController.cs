using Geardao.Deploy.Supervisor.Ef;
using Geardao.Deploy.Supervisor.EventBus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Geardao.Deploy.Supervisor.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ILogger<BaseController> _logger;
        
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }
    }
}