using System;
using System.Linq;
using Geardao.Deploy.Supervisor.Utilities;
using Microsoft.Extensions.Logging;

namespace Geardao.Deploy.Supervisor.Service
{
    public class AuthService : BaseService
    {
        public bool Auth(string token)
        {
            var auth = _dbContext.Auth.Where(c=>c.Token == token).FirstOrDefault(c => c.ExpiredTime >= DateTime.Now);
            if (auth!=null)
            {
                return true;
            }
            _logger.LogWarning("Invalid access from "+Address.GetIpAddress());
            return false;
        }
    }
}