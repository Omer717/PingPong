using PingPongServer.Abstractions;
using PingPongServer.Converter.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PingPongServer
{
    public class Server : IServer
    {
        private const int BUFFER_SIZE = 1024;

        private readonly TcpListener _listener;
        private readonly IConvert _converter;
        private List<TcpClient> _connectedSockets;

        public Server(IConvert converter, int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _connectedSockets = new List<TcpClient>();
            _converter = converter;
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
                        var recivedData = RecvData(client);
                        SendData(client, recivedData);
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

        public byte[] RecvData(TcpClient client)
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

            Console.WriteLine(_converter.ByteToString(buffer.Take(recv).ToArray()));
            return buffer.Take(recv).ToArray();
        }

        public void SendData(TcpClient client, byte[] data)
        {
            var stream = client.GetStream();
            stream.Write(data, 0, Buffer.ByteLength(data));
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
