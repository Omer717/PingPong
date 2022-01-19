using PingPongClient.Converter.Abstractions;
using System.Text;

namespace PingPongClient.Converter
{
    public class FromByteConverter : IFromByteConverter
    {
        public object ObjectFromBytes(byte[] bytes)
        {
            throw new System.NotImplementedException();
        }

        public string StringFromBytes(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
