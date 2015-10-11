using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace clientServerCSharp
{
    class Program
    {

        private static ManualResetEvent waitHandle = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            tcpServer app = new tcpServer(serverSettings.Default.port);     // set the server port
            app.killProgramEvent_ += quitProgram;
            waitHandle.WaitOne();
        }
        static void quitProgram(object sender, EventArgs e)
        {
            waitHandle.Set();
        }
    }
}
