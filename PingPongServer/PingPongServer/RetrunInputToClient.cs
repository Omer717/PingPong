using PingPongServer.Abstractions;
using System.Net.Sockets;

namespace PingPongServer
{
    public class RetrunInputToClient : IServerAction
    {
        private readonly IServerSender _sender;
        private readonly IServerReciver _reciver;

        public RetrunInputToClient(IServerSender sender, IServerReciver reciver)
        {
            _sender = sender;
            _reciver = reciver;
        }
        public void Execute(TcpClient client)
        {
            var data = _reciver.ReciveData(client);
            _sender.SendData(client, data);
        }
    }
}
