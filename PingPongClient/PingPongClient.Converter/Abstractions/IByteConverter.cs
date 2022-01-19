namespace PingPongClient.Converter.Abstractions
{
    public interface IByteConverter
    {
        byte[] Convert(string value);
        byte[] Convert(object value);
    }
}
