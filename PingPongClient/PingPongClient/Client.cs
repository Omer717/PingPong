using PingPongClient.Abstractions;
using System.IO;
using System.Net.Sockets;

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

        public string RecieveBytes()
        {
            var reader = new StreamReader(_stream);
            return reader.ReadLine();
        }

        public void SendBytes(byte[] data, int byteCount)
        {
            _stream.Write(data, 0, byteCount);
        }
    }
}
