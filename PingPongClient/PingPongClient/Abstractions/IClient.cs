namespace PingPongClient.Abstractions
{
    public interface IClient
    {
        void Start();
        void SendMessage(string message);
        string RecieveMessage();
    }
}
