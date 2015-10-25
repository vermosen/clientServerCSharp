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
        protected Dictionary<string, tcpConnection> connections_;               // connection dictionary
        protected Socket listener_;                                             // the listening socket

        public tcpServer(int port)
        {
            // on startup, we create a socket to catch incoming 
            // connection attempt
            listener_ = new Socket(
                AddressFamily.InterNetwork  ,
                SocketType.Stream           ,
                ProtocolType.Tcp            );

            listener_.Bind          (new IPEndPoint(IPAddress.Any, port));
            listener_.Listen        (10);
            listener_.BeginAccept   (new AsyncCallback(onClientConnect), null);

            connections_ = new Dictionary<string, tcpConnection>();

            Console.WriteLine("waiting for incoming connection...");
        }

        protected void onClientConnect(IAsyncResult res)
        {
            try
            {
                tcpConnection conn = new tcpConnection(listener_.EndAccept(res));
                IPEndPoint endPoint = (IPEndPoint)conn.socket.RemoteEndPoint;

                connections_.Add(Dns.GetHostEntry(endPoint.Address).HostName, conn);
                Console.WriteLine(
                    DateTime.Now.ToString() +
                    " new connection from " +
                    Dns.GetHostEntry(endPoint.Address).HostName);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    DateTime.Now.ToString() +
                    " new connection attempt failed: " +
                    e.Message);
            }
            finally
            {
                listener_.BeginAccept(new AsyncCallback(onClientConnect), null);
            }
        }

        protected void onClientDisconnect(IAsyncResult res)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(
                    DateTime.Now.ToString() +
                    " new disconnection attempt failed: " +
                    e.Message);
            }
        }
    }
}
