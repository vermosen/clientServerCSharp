using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace clientServerCSharp
{
    public delegate void killAppDelegate(object sender, EventArgs e);

    class tcpServer
    {
        
        public event killAppDelegate killProgramEvent_;

        private int             port_       ;
        private EventLog        eventLogger_;
        string                  serverKey_  ;

        private Dictionary<string, Socket> socketMap_;                          // network dictionary

        public tcpServer(int port)
        {
            port_ = port;
            serverKey_ = "server_" + Environment.MachineName;                   // key to retrieve the entry socket
            socketMap_ = new Dictionary<string, Socket>();
            socketMap_.Add(serverKey_, new Socket(                              // we attache the socket to the current machine name
                AddressFamily.InterNetwork  ,                                   
                SocketType.Stream           ,
                ProtocolType.Tcp            ));

            // bind the end point
            socketMap_[serverKey_].Bind(new IPEndPoint(IPAddress.Any, port_));
            socketMap_[serverKey_].Listen(10);
            socketMap_[serverKey_].BeginAccept(new AsyncCallback(OnClientConnect), null);

            eventLogger_ = new EventLog();

            if (!System.Diagnostics.EventLog.SourceExists("MySource"))          // register source
            {
                EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }

            eventLogger_.Source = "MySource";
            eventLogger_.Log = "MyNewLog"   ;

        }

        public void OnClientConnect(IAsyncResult async)
        {
            eventLogger_.WriteEntry("new incomming connection", EventLogEntryType.Information);

            // now we expect the distant machine name 
            Socket sock = socketMap_[serverKey_].EndAccept(async);
            IPEndPoint endPoint = (IPEndPoint)sock.RemoteEndPoint;
            string hostName = Dns.GetHostEntry(endPoint.Address).HostName;

            try
            {
                socketMap_.Add(hostName, sock);
            }
            catch (Exception e)
            {
                eventLogger_.WriteEntry("an error occured", EventLogEntryType.Error);
                if (killProgramEvent_ != null)
                killProgramEvent_(this, EventArgs.Empty);
            }

            testSend(hostName);

        }

        protected void testSend(string clientName)
        {
            // now we try to send a message to the client
            string activityPath = 
        }
    }
}
