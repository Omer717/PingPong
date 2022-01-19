using PingPongServer.Converter;


namespace PingPongServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var converter = new ObjectConverter();
            //var server = new Server(converter, int.Parse(args[0]));
            var server = new Server(converter, 1337);
            server.Start();
        }
    }
}
