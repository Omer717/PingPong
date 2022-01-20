using PingPongServer.Abstractions;
using System;
using System.Net.Sockets;

namespace PingPongServer
{
    public class DataSender : IServerSender
    {
        public void SendData(TcpClient client, byte[] data)
        {
            var stream = client.GetStream();
            stream.Write(data, 0, Buffer.ByteLength(data));
        }
    }
}
