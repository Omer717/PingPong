using log4net;
using log4net.Config;

namespace PingPongServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

            var serverAction = new RetrunInputToClient(new DataSender(), new DataReciver());
            var server = new Server(serverAction, int.Parse(args[0]));
            server.Start();
        }
    }
}
