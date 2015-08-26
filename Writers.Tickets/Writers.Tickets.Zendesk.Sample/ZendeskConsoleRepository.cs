using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Writers.Tickets.Zendesk.Sample
{
    public class ZendeskConsoleRepository : ZendeskRepository
    {
        public ZendeskConsoleRepository()
            //
            : base(new ZendeskConsoleProject())
        { 
        }
    }
}
