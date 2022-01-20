using PingPongClient.Converter;
using PingPongClient.UI;

namespace PingPongClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var clientLogic = new Client(args[0], int.Parse(args[1]));
            var clientLogic = new Client("127.0.0.1", 1337);
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            var converter = new ToByteConverter();
            var fromConverter = new FromByteConverter();
            var personProvider = new PersonObjectProvider(input, output);

            var client = new ClientWrapper(clientLogic, input, output, converter, fromConverter, personProvider);
            client.RunPingPongClient();
        }
    }
}
