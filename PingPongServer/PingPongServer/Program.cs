namespace PingPongServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serverAction = new RetrunInputToClient(new DataSender(), new DataReciver());

            //var server = new Server(int.Parse(args[0]));
            var server = new Server(serverAction, 1337);
            server.Start();
        }
    }
}
