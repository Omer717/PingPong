using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using PingPongServer.Abstractions;

namespace PingPongServer
{
    public class Server : IServer
    {
        private const int BUFFER_SIZE = 1024;

        private readonly IPAddress _address;
        private readonly IPEndPoint _endPoint;
        private readonly Socket _socket;

        private byte[] _buffer;

        public Server(int port)
        {
            _buffer = new byte[BUFFER_SIZE];

            _address = IPAddress.Parse("0.0.0.0");
            _endPoint = new IPEndPoint(_address, port);
            _socket = new Socket(_address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            _socket.Bind(_endPoint);
            _socket.Listen(5);
            var newSocket = _socket.Accept();
            while (true)
            {
                
                string userData = null;

                int bytesRec = newSocket.Receive(_buffer);
                int recv = 0;
                foreach (var b in _buffer)
                {
                    if (b != 0)
                    {
                        recv++;
                    }
                }
                userData += Encoding.ASCII.GetString(_buffer, 0, bytesRec);


                Console.WriteLine(userData);
            }
        }
    }
}
