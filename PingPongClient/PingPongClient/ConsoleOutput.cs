using PingPongClient.Abstractions;
using System;

namespace PingPongClient
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
