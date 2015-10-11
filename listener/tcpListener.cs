using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace listener
{
    public partial class tcpListener : ServiceBase
    {
        // members
        private Socket  socket_ ;
        IPEndPoint      ipEnd_  ;

        // ctor
        public tcpListener()
        {
            InitializeComponent();

            if (!System.Diagnostics.EventLog.SourceExists("MySource"))  // register source
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLogger.Source  = "MySource";
            eventLogger.Log     = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLogger.WriteEntry("service starting...", EventLogEntryType.Information);

            // attempt to connect to the server
            IPAddress ip = IPAddress.Parse("127.0.0.1");                // TODO: convert args into ip/port
            int iPortNo = 12437;

            socket_ = new Socket(AddressFamily.InterNetwork,            // new socket
                                    SocketType.Stream,
                                    ProtocolType.Tcp);

            ipEnd_ = new IPEndPoint(ip, iPortNo);

            connect();
        }

        protected void connect()
        {
            eventLogger.WriteEntry("attempt to connect to the server", EventLogEntryType.Information);

            try
            {
                socket_.Connect(ipEnd_);
            }
            catch (Exception e)
            {
                eventLogger.WriteEntry("connection attempt failed", EventLogEntryType.Error);
                throw e;
            }

            if (socket_.Connected)
            {
                eventLogger.WriteEntry("connection successfull", EventLogEntryType.Information);
            }

        }

        protected override void OnStop() 
        {
            eventLogger.WriteEntry("service stopping...", EventLogEntryType.Information);
        }

        private void eventLogger_EntryWritten(object sender, EntryWrittenEventArgs e) {}
    }
}
