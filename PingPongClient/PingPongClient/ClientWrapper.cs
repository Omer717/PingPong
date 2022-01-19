using PingPongClient.Abstractions;
using PingPongClient.UI.Abstractions;

namespace PingPongClient
{
    public class ClientWrapper
    {
        private readonly IClient _client;
        private readonly IInput _input;
        private readonly IOutput _output;

        public ClientWrapper(IClient client, IInput input, IOutput output)
        {
            _client = client;
            _input = input;
            _output = output;
        }

        public void RunPingPongClient()
        {
            _client.Start();

            while (true)
            {
                var userInput = _input.GetInput();
                _client.SendMessage(userInput);
                var receivedData = _client.RecieveMessage();
                _output.Write(receivedData);
            }
        }
    }
}
