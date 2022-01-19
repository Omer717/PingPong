using System.Net.Sockets;

namespace PingPongServer.Abstractions
{
    public interface IServer
    {
        void Start();
        void SendMessage(Socket socket, string message);
        string RecvMessage(Socket socket);
        void WaitForNewClients();
        void CreateSocketThread(Socket socket);
    }
}
