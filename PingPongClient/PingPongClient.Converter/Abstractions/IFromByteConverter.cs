namespace PingPongClient.Converter.Abstractions
{
    public interface IFromByteConverter
    {
        string StringFromBytes(byte[] bytes);
        object ObjectFromBytes(byte[] bytes);
    }
}
