using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kestrelancy.Modules
{
    public class HomeModule:Nancy.NancyModule
    {
        public HomeModule()
        {
            Get("/", _ => { return "Hello Nancy,Hello Kestrel"; });
        }
    }
}
