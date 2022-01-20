using PingPongClient.Abstractions;
using PingPongClient.Converter;
using PingPongClient.UI;

namespace PingPongClient
{
    public class ClientWrapperFactory : IClientWrapperFactory
    {
        public ClientWrapper Create(string ip, int port)
        {
            var clientLogic = new Client(ip, port);
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            var converter = new ToByteConverter();
            var fromConverter = new FromByteConverter();
            var personProvider = new PersonObjectProvider(input, output);

            return new ClientWrapper(clientLogic, input, output, converter, fromConverter, personProvider);
        }
    }
}
