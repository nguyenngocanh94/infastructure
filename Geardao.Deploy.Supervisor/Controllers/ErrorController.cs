using Microsoft.AspNetCore.Mvc;

namespace Geardao.Deploy.Supervisor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : BaseController
    {
        [HttpGet("{code}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult<string> Index(int code)
        {
            switch (code)
            {
                case 401:
                    return "401 Unauthorized";
                default:
                    return "404 Not Found";
            }
        }
    }
}