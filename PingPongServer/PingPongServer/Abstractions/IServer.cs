using System.Net.Sockets;

namespace PingPongServer.Abstractions
{
    public interface IServer
    {
        void Start();
        void WaitForNewClients();
        void CreateClientThread(TcpClient socket);
    }
}
