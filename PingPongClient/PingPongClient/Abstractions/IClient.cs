using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.Abstractions
{
    public interface IClient
    {
        void SendMessage(string message);
        string RecieveMessage();
    }
}
