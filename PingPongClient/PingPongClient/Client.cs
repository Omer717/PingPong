using PingPongClient.Abstractions;
using System.IO;
using System.Linq;
using System.Net.Sockets;

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

        public byte[] RecieveBytes()
        {
            byte[] buffer = new byte[BUFFER_SIZE];
            _stream.Read(buffer, 0, buffer.Length);
            int recv = 0;
            foreach (var b in buffer)
            {
                if (b != 0)
                {
                    recv++;
                }
            }

            //-1 to remove \n from the input
            var data = buffer.Take(recv-1).ToArray();
            return data;
        }

        public void SendBytes(byte[] data, int byteCount)
        {
            _stream.Write(data, 0, byteCount);
        }
    }
}
