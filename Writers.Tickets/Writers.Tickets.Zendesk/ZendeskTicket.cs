using System;
using System.Linq;
using ZendeskApi_v2.Models.Tickets;

namespace Writers.Tickets.Zendesk
{
    public class ZendeskTicket : ITicket<Int64?>
    {
        public Int64? Identifier { set; get; }

        public String Subject { set; get; }

        public String Body { set; get; }

        public String[] Tags { set; get; }

        public String Priority { set; get; }
    }
}
