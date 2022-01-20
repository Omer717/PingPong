using PingPongServer.Abstractions;
using System.Linq;
using System.Net.Sockets;

namespace PingPongServer
{
    public class DataReciver : IServerReciver
    {
        private const int BUFFER_SIZE = 1024;

        public byte[] ReciveData(TcpClient client)
        {
            var stream = client.GetStream();
            byte[] buffer = new byte[BUFFER_SIZE];
            stream.Read(buffer, 0, buffer.Length);
            int recv = 0;
            for (int i = buffer.Length - 1; i > 0; i--)
            {
                if (buffer[i] != 0)
                {
                    recv = ++i;
                    break;
                }
            }
            return buffer.Take(recv).ToArray();
        }
    }
}
