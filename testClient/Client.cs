using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace testClient
{
    public delegate void terminateDelegate();

    class Client
    {
        // members
        protected terminateDelegate terminateDlg_;          // terminate dlg

        // ctor
        Client(terminateDelegate dlg)
        {
            terminateDlg_ = dlg;
        }

        // static members
        static ManualResetEvent resetEvent;                 // blocking event

        // main
        static void Main(string[] args)
        {
            resetEvent = new ManualResetEvent(false);
            Client p = new Client(terminateCallback);
            resetEvent.WaitOne();                           // Blocks until Set() is called
        }

        // terminate method
        static void terminateCallback()
        {
            resetEvent.Set();                               // Allow the program to exit
        }
    }
}
