using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZendeskApi_v2.Models.Constants;

namespace Writers.Tickets.Zendesk
{
    public static class ZendeskTicketPriorities
    {
        public static String Low { get { return TicketPriorities.Low; } }

        public static String Normal { get { return TicketPriorities.Normal; } }

        public static String High { get { return TicketPriorities.High; } }

        public static String Urgent { get { return TicketPriorities.Urgent; } }
    }
}
