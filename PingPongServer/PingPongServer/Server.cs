using System;
using System.Collections.Generic;
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

        private readonly IPAddress _address;
        private readonly IPEndPoint _endPoint;
        private readonly Socket _listenSocket;

        private List<Socket> _connectedSockets;

        private byte[] _buffer;

        public Server(int port)
        {
            _buffer = new byte[BUFFER_SIZE];

            _address = IPAddress.Parse("0.0.0.0");
            _endPoint = new IPEndPoint(_address, port);
            _listenSocket = new Socket(_address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            _connectedSockets = new List<Socket>();
        }

        public void CreateSocketThread(Socket socket)
        {
            var socketThread = new Thread(() =>
            {
                var terminated = false;
                while (!terminated)
                {
                    try
                    {
                        var recivedData = RecvMessage(socket);
                        SendMessage(socket, recivedData);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Lost Connection to socket");
                        terminated = true;
                        _connectedSockets.Remove(socket);
                    }
                }
            });
            socketThread.Start();
        }

        public string RecvMessage(Socket socket)
        {
            int bytesRec = socket.Receive(_buffer);
            int recv = 0;
            foreach (var b in _buffer)
            {
                if (b != 0)
                {
                    recv++;
                }
            }
            var userData = Encoding.ASCII.GetString(_buffer, 0, bytesRec);
            return userData;
        }

        public void SendMessage(Socket socket, string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            socket.Send(messageBytes);
        }

        public void Start()
        {
            _listenSocket.Bind(_endPoint);
            _listenSocket.Listen(5);
            WaitForNewClients();
        }

        public void WaitForNewClients()
        {
            while (true)
            {
                var newSocket = _listenSocket.Accept();
                _connectedSockets.Add(newSocket);
                CreateSocketThread(newSocket);
            }
        }
    }
}
