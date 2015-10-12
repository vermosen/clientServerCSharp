using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace tcpMasterService
{
    // all the client I/O related components
    public partial class tcpMaster
    {
        private Dictionary<string, Socket> clientSocketMap_;                          // network dictionary

        private void initializeClientSocketMap()
        {
            eventLogger.WriteEntry("initialize client socket map", EventLogEntryType.Information);

            clientSocketMap_.Add(serverKey_, new Socket(                              // we attache the socket to the current machine name
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp));

            // bind the end point
            clientSocketMap_[serverKey_].Bind(new IPEndPoint(IPAddress.Any, tcpMasterServiceSettings.Default.clientPort));
            clientSocketMap_[serverKey_].Listen(10);
            clientSocketMap_[serverKey_].BeginAccept(new AsyncCallback(onClientConnect), null);
        }

        public void onClientConnect(IAsyncResult async)
        {
            eventLogger.WriteEntry("new client connection", EventLogEntryType.Information);

            // trying to get the distant machine name
            Socket sock = clientSocketMap_[serverKey_].EndAccept(async);
            IPEndPoint endPoint = (IPEndPoint)sock.RemoteEndPoint;
            string hostName = Dns.GetHostEntry(endPoint.Address).HostName;

            try
            {
                clientSocketMap_.Add(hostName, sock);
            }
            catch (Exception e)
            {
                eventLogger.WriteEntry("an error occured: " + e.Message, EventLogEntryType.Error);
            }
        }
    }
}
