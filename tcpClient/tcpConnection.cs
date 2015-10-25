using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary; 

namespace tcp
{
    // good reading http://stackoverflow.com/questions/3609280/sending-and-receiving-data-over-a-network-using-tcpclient
    // for object serialization, see also
    // http://stackoverflow.com/questions/2316397/sending-and-receiving-custom-objects-using-tcpclient-class-in-c-sharp
    // also see http://blog.stephencleary.com/2009/04/tcpip-net-sockets-faq.html
    // this class basically contains a socket and a buffer for building a message 
    // asynchronously from a tcp connection.
    // TODO: study if we need to encapsulate the listening process in a thread...
    // for disconnection, a message of length 0 means the connection has been closed
    public class tcpConnection : IDisposable
    {
        private Socket socket_                      ;
        private const int IntSize_      = 4         ;
        private const int BufferSize_   = 8 * 1024  ;

        private connectionDelegate connectionCallback_;
        private connectionDelegate disconnectionCallback_;

        public Socket socket                                       // may be necessary to expose the socket
        { 
            get { return socket_ ;}
            set { socket_ = value;}
        }

        public tcpConnection(   AddressFamily family        , 
                                SocketType socketType       , 
                                ProtocolType protocolType   )
        {
            socket_ = new Socket(family, socketType, protocolType);
        }

        public tcpConnection(Socket skt)
        {
            socket_ = skt;
        }

        public void connect(EndPoint ep, connectionDelegate callback)
        {
            socket_.BeginConnect(ep,
                new AsyncCallback(onConnection), socket_);

            connectionCallback_ = callback;
        }

        private void onConnection(IAsyncResult ar)
        {
            connectionCallback_();
        }
    
        
        public void Dispose() { dropConnection(); }

        protected void dropConnection()
        {
            socket_.Close();
        }
    }
}
