using System.Net.Sockets;

namespace PingPongServer.Abstractions
{
    public interface IServerSender
    {
        void SendData(TcpClient client, byte[] data);
    }
}
