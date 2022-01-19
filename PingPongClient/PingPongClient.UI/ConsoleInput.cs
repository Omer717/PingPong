using PingPongClient.UI.Abstractions;
using System;

namespace PingPongClient.UI
{
    public class ConsoleInput : IInput
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
