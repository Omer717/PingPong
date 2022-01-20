using PingPongServer.Converter;


namespace PingPongServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var converter = new ObjectConverter();
            var person = new Person("Omer", 18);
            //var server = new Server(converter, int.Parse(args[0]));
            var server = new Server(converter, 1337, person);
            server.Start();
        }
    }
}
