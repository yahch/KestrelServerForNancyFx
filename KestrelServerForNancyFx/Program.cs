using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KestrelServerForNancyFx
{
    class Program
    {
        static void Main(string[] args)
        {
            Kestrelancy.KestrelancyServer.Start(8080, Environment.CurrentDirectory);
        }
    }
}
