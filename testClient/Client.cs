using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace testClient
{
    public delegate void terminateDelegate();

    class Client
    {
        // members
        protected terminateDelegate terminateDlg_;          // terminate dlg
        protected IPEndPoint ipEnd_;
        protected Socket socket_;
        // ctor
        Client( terminateDelegate dlg)
        {
            terminateDlg_ = dlg;
            socket_ = new Socket(   AddressFamily.InterNetwork,            // new socket
                                    SocketType.Stream,
                                    ProtocolType.Tcp);
            
            Console.WriteLine("starting client...");
        }

        // static members
        static ManualResetEvent resetEvent;                 // blocking event

        // main
        static void Main(string[] args)
        {
            resetEvent = new ManualResetEvent(false);
            Client p = new Client(terminateCallback);
            p.connectServer("127.0.0.1", 10001);
            resetEvent.WaitOne();                           // Blocks until Set() is called
        }

        protected void connectServer(   string ipServer, 
                                        int port)
        {
            try
            {
                ipEnd_ = new IPEndPoint(IPAddress.Parse(ipServer), port);
                if (ipEnd_ == null) throw new Exception("ip not set");
                socket_.Connect(ipEnd_);
                if (!socket_.Connected) throw new Exception("socket unable to connect");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                terminateDlg_();
            }

            
        }

        // terminate method
        static void terminateCallback()
        {
            resetEvent.Set();                               // Allow the program to exit
        }
    }
}
