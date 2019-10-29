using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Geardao.Deploy.Supervisor.EventBus;
using Microsoft.Extensions.Logging;
using NetCoreServer;

namespace Geardao.Deploy.Supervisor.Socket
{
    public class SupervisorServerLauncher
    {
        private ILogger<SupervisorServer> _logger;
        private IEventBus _eventBus;
        public SupervisorServerLauncher(ILogger<SupervisorServer> logger, IEventBus eventBus)
        {
            _logger = logger;
            _eventBus = eventBus;
        }

        public void Init()
        {
            var context = new SslContext(SslProtocols.Tls12,
                new X509Certificate2("../ssl/Geardao.Deploy.Server.pfx", "geardao"));
            var server = new SupervisorServer(context, IPAddress.Any, 9091, _logger, _eventBus);
            _logger.LogInformation("Supervisor server have been already started");
            server.Start();

            while (true)
            {
                server.Process();
            }
        }
    }
}