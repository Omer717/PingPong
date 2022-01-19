using PingPongClient.UI.Abstractions;
using System;

namespace PingPongClient.UI
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
