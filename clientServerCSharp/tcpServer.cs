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
        private List<Socket>    sockets_    ;                                   // the first element is the listener
        private EventLog        eventLogger_;

        public tcpServer(int port)
        {
            port_ = port;

            sockets_ = new List<Socket>();
            sockets_.Add(new Socket(AddressFamily.InterNetwork  ,               // new socket
                                    SocketType.Stream           ,
                                    ProtocolType.Tcp            ));

            sockets_[0].Bind        (new IPEndPoint(IPAddress.Any, port_));     // bind the end point
            sockets_[0].Listen      (10);                                       // queue size
            sockets_[0].BeginAccept (new AsyncCallback(OnClientConnect), null); // callback

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

            try
            {
                sockets_.Add(sockets_[0].EndAccept(async));
            }
            catch (Exception e)
            {
                eventLogger_.WriteEntry("an error occured", EventLogEntryType.Error);
                if (killProgramEvent_ != null)
                killProgramEvent_(this, EventArgs.Empty);
            }
        }
    }
}
