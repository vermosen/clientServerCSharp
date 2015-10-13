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

namespace tcpMasterService
{
    public partial class tcpMaster : ServiceBase
    {
        private string serverKey_;

        public tcpMaster()
        {
            InitializeComponent();

            if (!System.Diagnostics.EventLog.SourceExists("masterService"))          // register source
            {
                EventLog.CreateEventSource(
                    "masterService", "batchManager");
            }

            eventLogger.Source  = "masterService"   ;
            eventLogger.Log     = "batchManager"    ;

            slaveSocketMap_ = new Dictionary<string, Socket>();                     // members initialization
            clientSocketMap_ = new Dictionary<string, Socket>();
            serverKey_ = "_" + Environment.MachineName;

            initializeSlaveSocketMap();
            initializeClientSocketMap();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }

        private void eventLogger_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
    }
}
