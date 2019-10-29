using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Geardao.Deploy.Supervisor.EventBus;
using Microsoft.Extensions.Logging;
using NetCoreServer;

namespace Geardao.Deploy.Supervisor.Socket
{
    public class SupervisorServer : SslServer
    {
        private ILogger<SupervisorServer> _logger;
        private IEventBus _eventBus;

        public SupervisorServer(SslContext context, IPAddress address, int port, ILogger<SupervisorServer> logger, IEventBus eventBus) :
            base(context, address, port)
        {
            _logger = logger;
            _eventBus = eventBus;
        }

        protected override SslSession CreateSession() { return new Session(this, _logger); }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat SSL server caught an error with code {error}");
        }

        public void Process()
        {
            
        }

        public void SendTo()
        {
            
        }
    }
    
    public class Session : SslSession
    {
        private ILogger<SupervisorServer> _logger;
        public Session(SslServer server, ILogger<SupervisorServer> logger) : base(server)
        {
            _logger = logger;
        }
        
        protected override void OnConnected()
        {
            _logger.LogTrace($"Chat SSL session with Id {Id} connected!");
            
        }
        
        protected override void OnHandshaked()
        {
            _logger.LogTrace($"Chat SSL session with Id {Id} handshaked!");
        }
        
        protected override void OnDisconnected()
        {
            _logger.LogTrace($"Chat SSL session with Id {Id} disconnected!");
        }
        
        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            Console.WriteLine("Incoming: " + message);

            // Multicast message to all connected sessions
            Server.Multicast(message);
            // If the buffer starts with '!' the disconnect the current session
            if (message == "!")
                Disconnect();
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat SSL session caught an error with code {error}");
        }
    }
    
       
}