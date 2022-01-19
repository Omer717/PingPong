using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using PingPongServer.Abstractions;

namespace PingPongServer
{
    public class Server : IServer
    {
        private const int BUFFER_SIZE = 1024;

        private readonly TcpListener _listener;
        private List<TcpClient> _connectedSockets;

        private byte[] _buffer;

        public Server(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _connectedSockets = new List<TcpClient>();  
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
                        var recivedData = RecvMessage(client);
                        SendMessage(client, recivedData);
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

        public string RecvMessage(TcpClient client)
        {
            var stream = client.GetStream();
            byte[] buffer = new byte[BUFFER_SIZE];
            stream.Read(buffer, 0, buffer.Length);
            int recv = 0;
            foreach (var b in buffer)
            {
                if (b != 0)
                {
                    recv++;
                }
            }
            var data = Encoding.UTF8.GetString(buffer, 0, recv);
            return data;
        }

        public void SendMessage(TcpClient client, string message)
        {
            var stream = client.GetStream();
            var writer = new StreamWriter(stream);
            writer.WriteLine(message);
            writer.Flush();
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
