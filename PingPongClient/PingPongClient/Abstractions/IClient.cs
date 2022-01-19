namespace PingPongClient.Abstractions
{
    public interface IClient
    {
        void SendMessage(string message);
        string RecieveMessage();
    }
}
