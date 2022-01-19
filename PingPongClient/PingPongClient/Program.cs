using PingPongClient.UI;
using System;

namespace PingPongClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var client = new Client(args[0], int.Parse(args[1]));
            var clientSocket = new Client("127.0.0.1", 1337);
            var input = new ConsoleInput();
            var output = new ConsoleOutput();

            var client = new ClientWrapper(clientSocket, input, output);
            client.RunPingPongClient();
        }
    }
}
