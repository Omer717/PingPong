namespace PingPongClient.Converter.Abstractions
{
    public interface IConverter
    {
        byte[] Convert(string value);
        byte[] Convert(object value);
    }
}
