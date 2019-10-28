using Microsoft.AspNetCore.Http;

namespace Geardao.Deploy.Supervisor.Service
{
    public class HttpContextService : IHttpContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetRemoteIp()
        {
           return _httpContextAccessor.HttpContext.Request.HttpContext.Connection.RemoteIpAddress?.ToString();
        }
    }

    public interface IHttpContext
    {
        string GetRemoteIp();
    }
}