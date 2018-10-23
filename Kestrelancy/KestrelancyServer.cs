using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kestrelancy
{
    public class KestrelancyServer
    {
        public static void Start(int port, string root)
        {
            var host = new WebHostBuilder()
               .UseUrls("http://*:" + port + "/")
               .UseWebRoot(Path.Combine(root, "wwwroot"))
               .UseContentRoot(root)
               .UseKestrel()
               .UseStartup<Startup>()
               .Build();

            host.Run();
        }
    }
}
