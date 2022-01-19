using PingPongClient.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
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

        private readonly TcpClient _client;
        private readonly NetworkStream _stream;

        public Client(string ip, int port)
        {
            _client = new TcpClient(ip, port);
            _stream = _client.GetStream();
        }

        public string RecieveMessage()
        {
            var reader = new StreamReader(_stream);
            return reader.ReadLine();
        }

        public void SendMessage(string message)
        {
            int byteCount = Encoding.ASCII.GetByteCount(message);
            byte[] buffer = new byte[byteCount];
            buffer = Encoding.ASCII.GetBytes(message);
            _stream.Write(buffer, 0, byteCount);
        }
    }
}
