using System.Net.Sockets;

namespace PingPongServer.Abstractions
{
    public interface IServer
    {
        void Start();
        void SendMessage(Socket socket, string message);
    }
}
