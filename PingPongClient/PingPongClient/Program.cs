using PingPongClient.UI;
using System;

namespace PingPongClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clientLogic = new Client("127.0.0.1", 1337);
            var input = new ConsoleInput();
            var output = new ConsoleOutput();

            var client = new ClientWrapper(clientLogic, input, output);
            client.RunPingPongClient();
        }
    }
}
