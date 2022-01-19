using PingPongServer.Converter;


namespace PingPongServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var converter = new ObjectConverter();
            var server = new Server(converter, int.Parse(args[0]));
            server.Start();
        }
    }
}
