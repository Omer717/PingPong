using PingPongClient.Converter.Abstractions;
using System;
using System.Text;

namespace PingPongClient.Converter
{
    public class ToByteConverter : IConverter
    {
        public byte[] Convert(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }

        public byte[] Convert(object value)
        {
            throw new NotImplementedException();
        }
    }
}
