using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace testServer
{
    public delegate void terminateDelegate();                   // terminate the program

    class Server
    {
        // members
        protected Dictionary<string, Socket> socketMap_ ;       // network dictionary
        protected terminateDelegate terminateDlg_       ;       // terminate dlg
        
        // ctor
        Server(terminateDelegate dlg)
        {
            terminateDlg_ = dlg;
            socketMap_ = new Dictionary<string, Socket>();

            socketMap_.Add("SERVER", new Socket(                // we attache the socket to the current machine name
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp));

            socketMap_["SERVER"].Bind(new IPEndPoint(IPAddress.Any, 10001));
            socketMap_["SERVER"].Listen(10);
            socketMap_["SERVER"].BeginAccept(new AsyncCallback(onClientConnect), null);

            Console.WriteLine("starting server...");
        }

        // static members
        static ManualResetEvent resetEvent_;                    // blocking event
        
        // main
        static void Main(string[] args)
        {
            resetEvent_ = new ManualResetEvent(false);          // Blocks until Set() is called
            Server p = new Server(terminateCallback);
            resetEvent_.WaitOne();               
        }

        public void onClientConnect(IAsyncResult async)
        {
            // trying to get the distant machine name
            Socket sock = socketMap_["SERVER"].EndAccept(async);
            IPEndPoint endPoint = (IPEndPoint)sock.RemoteEndPoint;
            string hostName = Dns.GetHostEntry(endPoint.Address).HostName;

            try
            {
                socketMap_.Add(hostName, sock);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                terminateCallback();
            }
        }

        // terminate method
        static void terminateCallback()
        {
            resetEvent_.Set();                               // Allow the program to exit
        }
    }
}


