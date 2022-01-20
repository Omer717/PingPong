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
        private readonly IServerAction _serverAction;
        private readonly TcpListener _listener;
        private List<TcpClient> _connectedSockets;

        public Server(IServerAction serverAction, int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
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
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Lost Connection to client");
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
            WaitForNewClients();
        }

        public void WaitForNewClients()
        {
            while (true)
            {
                var newClient = _listener.AcceptTcpClient();
                _connectedSockets.Add(newClient);
                CreateClientThread(newClient);
            }
        }
    }
}
