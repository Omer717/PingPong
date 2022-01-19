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

        public ClientWrapper(IClient client, IInput input, IOutput output, IByteConverter converter)
        {
            _client = client;
            _input = input;
            _output = output;
            _converter = converter;
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
                _output.Write(receivedData);
            }
        }
    }
}
