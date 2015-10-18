using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace tcp
{
    public class tcpClient
    {
        internal tcpConnection conn_;

        public tcpClient()
        {
            conn_ = new tcpConnection(  AddressFamily.InterNetwork  ,
                                        SocketType.Stream           ,
                                        ProtocolType.Tcp            );
        }
        protected void connectServer(string ipServer, int port)
        {
            try
            {
                conn_.socket.Connect(new IPEndPoint(IPAddress.Parse(ipServer), port));

                if (!conn_.socket.Connected) 
                    throw new Exception("socket unable to connect");
            }
            catch (Exception e)
            {
            }
        }
    }
}
