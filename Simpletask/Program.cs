using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simpletask
{
    class Program
    {
        // a simple task designed to be called by a 
        // service and to return some value
        static int Main(string[] args)
        {
            if (args.GetLength(0) != 2) return -1;
            else return (int)(Convert.ToDouble(args[0]) + Convert.ToDouble(args[1]));
        }
    }
}
