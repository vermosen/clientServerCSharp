using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace tcpMasterService
{
    // all the slave I/O related components
    public partial class tcpMaster
    {
        private Dictionary<string, Socket> slaveSocketMap_;                          // network dictionary

        private void initializeSlaveSocketMap()
        {
            eventLogger.WriteEntry("initialize ", EventLogEntryType.Information);
            
            slaveSocketMap_.Add(serverKey_, new Socket(                              // we attache the socket to the current machine name
                AddressFamily.InterNetwork  ,                                   
                SocketType.Stream           ,
                ProtocolType.Tcp            ));

            // bind the end point
            slaveSocketMap_[serverKey_].Bind(new IPEndPoint(IPAddress.Any, tcpMasterServiceSettings.Default.slavePort));
            slaveSocketMap_[serverKey_].Listen(10);
            slaveSocketMap_[serverKey_].BeginAccept(new AsyncCallback(onSlaveConnect), null);
        }

        public void onSlaveConnect(IAsyncResult async)
        {
            eventLogger.WriteEntry("new slave connection", EventLogEntryType.Information);

            // trying to get the distant machine name
            Socket sock = slaveSocketMap_[serverKey_].EndAccept(async);
            IPEndPoint endPoint = (IPEndPoint)sock.RemoteEndPoint;
            string hostName = Dns.GetHostEntry(endPoint.Address).HostName;

            try
            {
                slaveSocketMap_.Add(hostName, sock);
            }
            catch (Exception e)
            {
                eventLogger.WriteEntry("an error occured: " + e.Message, EventLogEntryType.Error);
            }
        }
    }
}
