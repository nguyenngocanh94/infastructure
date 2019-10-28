using System;
using System.Linq;
using Geardao.Deploy.Supervisor.Ef;
using Geardao.Deploy.Supervisor.EventBus;
using Geardao.Deploy.Supervisor.Utilities;
using Microsoft.Extensions.Logging;

namespace Geardao.Deploy.Supervisor.Service
{
    public class AuthService : BaseService, IAuth
    {
        public bool Auth(string token)
        {
            var auth = _dbContext.Auth.Where(c=>c.Token == token).FirstOrDefault(c => c.ExpiredTime >= DateTime.Now);
            if (auth!=null)
            {
                return true;
            }
            _logger.LogWarning("Invalid access from "+ _httpContext.GetRemoteIp());
            return false;
        }

        public AuthService(SupervisorContext context, ILogger<BaseService> logger, IEventBus eventBus, IHttpContext httpContext) : base(context, logger, eventBus, httpContext)
        {
        }
    }

    public interface IAuth
    {
        bool Auth(string token);
    }
}