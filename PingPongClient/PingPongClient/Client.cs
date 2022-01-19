using PingPongClient.Abstractions;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace PingPongClient
{
    public class Client : IClient
    {
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
            var buffer = Encoding.ASCII.GetBytes(message);
            _stream.Write(buffer, 0, byteCount);
        }
    }
}
