using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geardao.Deploy.Supervisor.Utilities
{
    public class Address
    {
        public static string GetIpAddress(HttpContext request)
        {
            return request.Connection.RemoteIpAddress?.ToString();
        }
    }
}