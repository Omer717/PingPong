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
        private readonly Person _person;
        private List<TcpClient> _connectedSockets;

        public Server(IConvert converter, int port, Person person)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _connectedSockets = new List<TcpClient>();
            _converter = converter;
            _person = person;
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
                        var toSendBytes = _converter.ToBytes(_person);
                        Console.WriteLine(toSendBytes.Length);
                        SendData(client, toSendBytes);
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
