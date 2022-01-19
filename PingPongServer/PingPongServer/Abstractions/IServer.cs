using System.Net.Sockets;

namespace PingPongServer.Abstractions
{
    public interface IServer
    {
        void Start();
        void SendMessage(TcpClient socket, string message);
        string RecvMessage(TcpClient socket);
        void WaitForNewClients();
        void CreateClientThread(TcpClient socket);
    }
}
