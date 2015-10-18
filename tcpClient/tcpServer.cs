using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace tcp
{
    public class tcpServer
    {
        internal Dictionary<string, tcpConnection> connections_;                // clients dictionary
        protected string serverName_ = "SERVER";

        protected tcpServer()
        {
            connections_ = new Dictionary<string, tcpConnection>();

            connections_.Add(serverName_, new tcpConnection(                      // we attach the socket to the current machine name
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp));

            connections_[serverName_].socket.Bind(new IPEndPoint(IPAddress.Any, 10001));
            connections_[serverName_].socket.Listen(10);
            connections_[serverName_].socket.BeginAccept(new AsyncCallback(onClientConnect), null);
        }

        protected void onClientConnect(IAsyncResult res)
        {
            try
            {
                tcpConnection conn = new tcpConnection(connections_[serverName_].socket.EndAccept(res));
                IPEndPoint endPoint = (IPEndPoint)conn.socket.RemoteEndPoint;
                connections_.Add(Dns.GetHostEntry(endPoint.Address).HostName, conn);
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
