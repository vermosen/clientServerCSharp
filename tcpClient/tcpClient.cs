using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace tcp
{
    public delegate void connectionDelegate();

    public class tcpClient
    {
        internal tcpConnection      conn_;                   // connection to the remote host

        public tcpClient()
        {
            conn_ = new tcpConnection(  AddressFamily.InterNetwork  ,
                                        SocketType.Stream           ,
                                        ProtocolType.Tcp            );
        }

        public void connect(string ipServer, int port)
        {
            try
            {
                conn_.connect(
                    new IPEndPoint(IPAddress.Parse(ipServer), port),
                    (connectionDelegate)connectionCallback);
            }
            catch (Exception e)
            {
                Console.WriteLine("cannot connect: " + e.Message);
            }
        }

        public void connectionCallback()
        {
            Console.WriteLine("connected");
        }
    }
}
