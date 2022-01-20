using log4net;
using PingPongServer.Abstractions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PingPongServer
{
    public class Server : IServer
    {
        private ILog _logger = LogManager.GetLogger(typeof(Server));

        private readonly IServerAction _serverAction;
        private readonly TcpListener _listener;
        private List<TcpClient> _connectedSockets;

        public Server(IServerAction serverAction, int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _logger.Info($"Server started on port {port}");

            _connectedSockets = new List<TcpClient>();
            _serverAction = serverAction;
        }

        public void CreateClientThread(TcpClient client)
        {
            var socketThread = new Thread(() =>
            {
                var terminated = false;
                while (!terminated)
                {
                    try
                    {
                        _serverAction.Execute(client);
                        _logger.Info($"Performed client action {(IPEndPoint)client.Client.RemoteEndPoint}");
                    }
                    catch (Exception)
                    {
                        _logger.Error($"Lost connection to client {(IPEndPoint)client.Client.RemoteEndPoint}");
                        terminated = true;
                        _connectedSockets.Remove(client);
                    }
                }
            });
            socketThread.Start();
        }

        public void Start()
        {
            _listener.Start();
            _logger.Info("Starting listener...");
            WaitForNewClients();
        }

        public void WaitForNewClients()
        {
            while (true)
            {
                var newClient = _listener.AcceptTcpClient();
                _logger.Info($"Got a new client {(IPEndPoint)newClient.Client.RemoteEndPoint}");
                _connectedSockets.Add(newClient);
                CreateClientThread(newClient);
            }
        }
    }
}
