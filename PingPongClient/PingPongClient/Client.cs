using PingPongClient.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient
{
    public class Client : IClient
    {
        private const int BUFFER_SIZE = 1024;

        private readonly IPAddress _address;
        private readonly IPEndPoint _endpoint;
        private readonly Socket _socket;

        private byte[] _buffer;

        public Client(string ip, int port)
        {
            _buffer = new byte[BUFFER_SIZE];

            _address = IPAddress.Parse(ip);
            _endpoint = new IPEndPoint(_address, port);
  
            _socket = new Socket(_address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public string RecieveMessage()
        {
            int bytesRec = _socket.Receive(_buffer);
            return Encoding.ASCII.GetString(_buffer, 0, bytesRec);
        }

        public void SendMessage(string message)
        {
            var messageBytes = Encoding.ASCII.GetBytes($"{message}<EOF>");
            _socket.Send(messageBytes);
        }

        public void Start()
        {
            try
            {
                _socket.Connect(_endpoint);
                Console.WriteLine("Connected...");
                
                while (true)
                {
                    SendMessage(Console.ReadLine());
                    var a = RecieveMessage();
                    Console.WriteLine(a);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
