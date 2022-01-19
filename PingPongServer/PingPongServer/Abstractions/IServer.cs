using System.Net.Sockets;

namespace PingPongServer.Abstractions
{
    public interface IServer
    {
        void Start();
        void SendData(TcpClient socket, byte[] data);
        byte[] RecvData(TcpClient socket);
        void WaitForNewClients();
        void CreateClientThread(TcpClient socket);
    }
}
