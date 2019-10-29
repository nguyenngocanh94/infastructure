using Geardao.Deploy.Supervisor.Aop;
using Geardao.Deploy.Supervisor.Ef;
using Geardao.Deploy.Supervisor.Form;
using Geardao.Deploy.Supervisor.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Geardao.Deploy.Supervisor.Controllers
{
    public class WorkerController : BaseController
    {
        private WorkerService _service;
        public WorkerController(ILogger<BaseController> logger, WorkerService workerService) : base(logger)
        {
            _service = workerService;
        }
        
        [HttpPost]
        [TypeFilter(typeof(AuthenticationAttribute))]
        public void Post(AddWorkerForm form)
        {
            if (ModelState.IsValid)
            {
                _service.Add(new Ef.Model.Worker
                {
                    Ip = form.Ip,
                    Username = form.UserName,
                    Password = form.Password,
                });
            }
             
        }
    }
}