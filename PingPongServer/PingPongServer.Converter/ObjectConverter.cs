using PingPongServer.Converter.Abstractions;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PingPongServer.Converter
{
    public class ObjectConverter : IConvert
    {
        public string ByteToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public byte[] ToBytes(object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        public object ToObject(byte[] bytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(bytes, 0, bytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }
    }
}
