using PingPongClient.Converter.Abstractions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PingPongClient.Converter
{
    public class ToByteConverter : IByteConverter
    {
        public byte[] Convert(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }

        public byte[] Convert(object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            bf.Serialize(ms, obj);

            return ms.ToArray();
        }
    }
}
