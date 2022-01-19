using System;

namespace PingPongClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var client = new Client(args[0], int.Parse(args[1]));
            var client = new Client("127.0.0.1", 1337);
            client.Start();
        }
    }
}
