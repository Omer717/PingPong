using System.Net.Sockets;

namespace PingPongServer.Abstractions
{
    public interface IServerReciver
    {
        byte[] ReciveData(TcpClient client);
    }
}
