namespace PingPongServer.Converter.Abstractions
{
    public interface IConvert
    {
        byte[] ToBytes(object obj);

        object ToObject(byte[] bytes);
    }
}
