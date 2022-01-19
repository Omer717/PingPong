using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using PingPongServer.Abstractions;

namespace PingPongServer
{
    public class Server : IServer
    {
        private readonly IPHostEntry _entry;
        private readonly IPAddress _address;
        private readonly IPEndPoint _endPoint;
        private readonly Socket _socket;

        private byte[] _buffer;

        public Server(int port)
        {
            _buffer = new byte[1024];

            _entry = Dns.GetHostEntry(Dns.GetHostName());
            _address = IPAddress.Parse("0.0.0.0");
            _endPoint = new IPEndPoint(_address, port);
            _socket = new Socket(_address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            _socket.Bind(_endPoint);
            _socket.Listen(5);

            while (true)
            {
                var newSocket = _socket.Accept();
                string userData = null;

                while (true)
                {
                    int bytesRec = newSocket.Receive(_buffer);
                    userData += Encoding.ASCII.GetString(_buffer, 0, bytesRec);
                    if (userData.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }

                Console.WriteLine(userData);
            }
        }
    }
}
