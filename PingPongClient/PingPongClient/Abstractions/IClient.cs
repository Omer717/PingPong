namespace PingPongClient.Abstractions
{
    public interface IClient
    {
        void SendBytes(byte[] data, int byteCount);
        string RecieveBytes();
    }
}
