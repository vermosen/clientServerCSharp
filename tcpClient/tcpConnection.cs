using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace tcp
{
    // good reading http://stackoverflow.com/questions/3609280/sending-and-receiving-data-over-a-network-using-tcpclient
    // also see http://blog.stephencleary.com/2009/04/tcpip-net-sockets-faq.html
    // this class basically contains a socket and a buffer for building a message 
    // asynchronoulsy from a tcp connection.
    // TODO: study if we need to encapsulate the listening process in a thread...
    internal class tcpConnection : IDisposable
    {
        private Socket socket_;

        private const int IntSize_      = 4         ;
        private const int BufferSize_   = 8 * 1024  ;

        public Socket socket 
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

        private void beginReceive()
        {
            //this.socket_.BeginReceive(
            //        this.dataRcvBuf, 0,
            //        this.dataRcvBuf.Length,
            //        SocketFlags.None,
            //        new AsyncCallback(onBytesReceived),
            //        this);
        }

        private void onBytesReceived(IAsyncResult result)
        {
            // End the data receiving that the socket has done and get
            // the number of bytes read.
            int nBytesRec = this.socket_.EndReceive(result);
            // If no bytes were received, the connection is closed (at
            // least as far as we're concerned).
            if (nBytesRec <= 0)
            {
                this.socket_.Close();
                return;
            }
            // Convert the data we have to a string.
            //string strReceived = this.encoding.GetString(
            //    this.dataRcvBuf, 0, nBytesRec);

            // ...Now, do whatever works best with the string data.
            // You could, for example, look at each character in the string
            // one-at-a-time and check for characters like the "end of text"
            // character ('\u0003') from a client indicating that they've finished
            // sending the current message.  It's totally up to you how you want
            // the protocol to work.

            // Set up again to get the next chunk of data.
            //this.socket_.BeginReceive(
            //    this.dataRcvBuf, 0,
            //    this.dataRcvBuf.Length,
            //    SocketFlags.None,
            //    new AsyncCallback(this.onBytesReceived),
            //    this);
        }

        internal void asyncRead(NetworkStream str)
        {
            try
            {

            }
            catch (Exception)
            {
                dropConnection();
            }
        }

        internal void asyncWrite(NetworkStream str)
        {
            try
            {

            }
            catch (Exception)
            {
                dropConnection();
            }
        }

        public void Dispose() { dropConnection(); }

        protected void dropConnection()
        {
            socket_.Close();
        }
    }
}
