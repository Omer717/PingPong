using PingPongClient.Abstractions;
using PingPongClient.Common;
using PingPongClient.Converter.Abstractions;
using PingPongClient.UI.Abstractions;

namespace PingPongClient
{
    public class ClientWrapper
    {
        private readonly IClient _client;
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IByteConverter _converter;
        private readonly IFromByteConverter _fromConverter;
        private readonly IObjectProvider _objectProvider;

        public Person myPerson { get; set; }

        public ClientWrapper(IClient client, IInput input, IOutput output, IByteConverter converter, IFromByteConverter fromConverter, IObjectProvider objectProvider)
        {
            _client = client;
            _input = input;
            _output = output;
            _converter = converter;
            _fromConverter = fromConverter;
            _objectProvider = objectProvider;
        }

        public void RunPingPongClient()
        {
            while (true)
            {
                var userInput = _objectProvider.Provide();
                var bytes = _converter.Convert(userInput);
                _client.SendBytes(bytes, bytes.Length);
                var receivedData = _client.RecieveBytes();
                var parsedData = _fromConverter.ObjectFromBytes(receivedData);
                _output.WriteLine(parsedData.ToString());
            }
        }
    }
}
