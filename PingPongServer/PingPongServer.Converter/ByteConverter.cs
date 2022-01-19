using PingPongServer.Converter.Abstractions;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PingPongServer.Converter
{
    public class ByteConverter : IConvert
    {
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
