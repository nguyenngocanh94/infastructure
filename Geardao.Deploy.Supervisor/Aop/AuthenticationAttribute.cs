using Geardao.Deploy.Supervisor.Ef;
using Geardao.Deploy.Supervisor.Form;
using Geardao.Deploy.Supervisor.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Geardao.Deploy.Supervisor.Aop
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        private readonly SupervisorContext _dbContext;
        private readonly ILogger<AuthenticationAttribute> _logger;
        private readonly IAuth _auth;
        public AuthenticationAttribute(SupervisorContext context, ILogger<AuthenticationAttribute> logger, IAuth auth)
        {
            _dbContext = context;
            _auth = auth;
            _logger = logger;
        }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            BaseForm form = filterContext.ActionArguments["form"] as BaseForm;
            if (form==null||!_auth.Auth(form.Token))
            {
                filterContext.Result = new RedirectResult("/api/error/401");
            }
        }
        
    }
}