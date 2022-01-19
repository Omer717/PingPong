using PingPongClient.UI;

namespace PingPongClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            var clientLogic = new Client(args[0], int.Parse(args[1]));
            var input = new ConsoleInput();
            var output = new ConsoleOutput();

            var client = new ClientWrapper(clientLogic, input, output);
            client.RunPingPongClient();
        }
    }
}
