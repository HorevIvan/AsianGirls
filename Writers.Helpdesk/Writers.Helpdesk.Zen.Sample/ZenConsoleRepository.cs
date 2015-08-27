using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Writers.Tickets.Zendesk.Sample
{
    public class ZenConsoleRepository : ZenService
    {
        public ZenConsoleRepository()
            //
            : base(new ZenConsoleProject())
        { 
        }
    }
}
