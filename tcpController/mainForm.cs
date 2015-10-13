using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace tcpController
{
    public partial class mainForm : Form
    {
        private Socket socket_;
        private bool validIP_;
        private IPEndPoint ipEnd_;

        public mainForm()
        {
            InitializeComponent();

            if (!System.Diagnostics.EventLog.SourceExists("tcpController"))  // register source
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "tcpController", "batchManager");
            }
            eventLogger.Source  = "tcpController"   ;
            eventLogger.Log     = "batchManager"    ;

            socket_ = new Socket(   AddressFamily.InterNetwork  ,           // new socket
                                    SocketType.Stream           ,
                                    ProtocolType.Tcp            );
        }

        private void mainForm_Load(object sender, EventArgs e)
        {          
            // attempt to connect to the server
            connect();
        }

        // method to connect to the main service
        private void connect()
        {
            if (ipEnd_ == null) return;

            eventLogger.WriteEntry("attempt to connect to the server", EventLogEntryType.Information);

            try
            {
                socket_.Connect(ipEnd_);

                if (socket_.Connected)
                {
                    eventLogger.WriteEntry("connection successfull", EventLogEntryType.Information);
                }
            }
            catch (Exception e)
            {
                eventLogger.WriteEntry("connection attempt failed", EventLogEntryType.Error);
                throw e;
            }
        }

        private void trySplitIPAdress()
        {
            validIP_ = false;

            try
            {
                string[] ipPort = serverIPBox.Text.Split(':');                      // read the field
                ipEnd_ = new IPEndPoint(
                    IPAddress.Parse(ipPort[0]), 
                    Convert.ToInt16(ipPort[1]));
            }
            catch (Exception)
            {
                eventLogger.WriteEntry("ip address is not valid...", EventLogEntryType.Information);
            }
        }

        private void eventLogger_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e) { }

        private void serverIPBox_Leave(object sender, EventArgs e)
        {
            trySplitIPAdress();
        }
    }
}
