using PingPongClient.Converter;
using PingPongClient.UI;

namespace PingPongClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            var wrapperFactory = new ClientWrapperFactory();
            //var clientWrapperInstance = wrapperFactory.Create(args[0], int.Parse(args[1]));
            var clientWrapperInstance = wrapperFactory.Create("127.0.0.1", 1337);
            clientWrapperInstance.RunPingPongClient();
        }
    }
}
