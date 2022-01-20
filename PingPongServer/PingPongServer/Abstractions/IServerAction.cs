using System.Net.Sockets;

namespace PingPongServer.Abstractions
{
    public interface IServerAction
    {
        void Execute(TcpClient client);
    }
}
