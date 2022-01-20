using PingPongClient.Abstractions;
using PingPongClient.Converter.Abstractions;
using PingPongClient.UI.Abstractions;
using System.Text;

namespace PingPongClient
{
    public class ClientWrapper
    {
        private readonly IClient _client;
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IByteConverter _converter;
        private readonly IFromByteConverter _fromConverter;

        public ClientWrapper(IClient client, IInput input, IOutput output, IByteConverter converter, IFromByteConverter fromConverter)
        {
            _client = client;
            _input = input;
            _output = output;
            _converter = converter;
            _fromConverter = fromConverter;
        }

        public void RunPingPongClient()
        {
            while (true)
            {
                var userInput = _input.GetInput();
                var byteCount = Encoding.ASCII.GetByteCount(userInput);
                var bytes = _converter.Convert(userInput);
                _client.SendBytes(bytes, byteCount);
                var receivedData = _client.RecieveBytes();
                var parsedData = (Person)_fromConverter.ObjectFromBytes(receivedData);
                _output.Write(parsedData.ToString());
            }
        }
    }
}
