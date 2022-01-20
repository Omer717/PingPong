namespace PingPongClient.Abstractions
{
    public interface IClientWrapperFactory
    {
        ClientWrapper Create(string ip, int port);
    }
}
