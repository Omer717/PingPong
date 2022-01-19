using System;

namespace PingPongClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new Client(args[0], int.Parse(args[1]));
            client.Start();
        }
    }
}
