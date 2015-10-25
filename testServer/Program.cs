using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using tcp;

namespace testServer
{
    public delegate void terminateDelegate();                   // terminate the program

    class Program
    {
        // static members
        static ManualResetEvent resetEvent_;                    // blocking event
        
        // main
        static void Main(string[] args)
        {
            resetEvent_ = new ManualResetEvent(false);          // Blocks until Set() is called
            tcpServer p = new tcpServer(10001);
            resetEvent_.WaitOne();               
        }
    }
}


