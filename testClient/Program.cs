using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using tcp;

namespace testClient
{
    public delegate void terminateDelegate();

    class Program
    {
        // static members
        static ManualResetEvent resetEvent;                 // blocking event

        // main
        static void Main(string[] args)
        {
            resetEvent = new ManualResetEvent(false);
            tcpClient c = new tcpClient();
            c.connect("127.0.0.1", 10001);
            resetEvent.WaitOne();                           // Blocks until Set() is called
        }
    }
}
