namespace PingPongServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var server = new Server(int.Parse(args[0]));
            server.Start();
        }
    }
}
