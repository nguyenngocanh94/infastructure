using System.Threading.Tasks;
using Geardao.Deploy.Supervisor.Aop;
using Geardao.Deploy.Supervisor.Ef;
using Geardao.Deploy.Supervisor.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Geardao.Deploy.Supervisor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeployController : BaseController
    {
        [HttpPost]
        [TypeFilter(typeof(AuthenticationAttribute))]
        public void Post(TaskForm form)
        {
            if (ModelState.IsValid)
            {
                
            }
             
        }
    }

   
}