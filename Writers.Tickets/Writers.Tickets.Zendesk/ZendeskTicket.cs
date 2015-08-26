using System;
using System.Linq;
using TIdentifier = System.Nullable<System.Int64>;
using ZTicket = ZendeskApi_v2.Models.Tickets.Ticket;

namespace Writers.Tickets.Zendesk
{
    public class ZendeskTicket : ITicket<TIdentifier>
    {
        public ZTicket BaseTicket { private set; get; }

        public ZendeskTicket(ZTicket baseTicket)
        {
            BaseTicket = baseTicket;
        }

        public TIdentifier Identifier
        {
            private set { BaseTicket.Id = value; }

            get { return BaseTicket.Id; }
        }

        public String Subject
        {
            private set { BaseTicket.Subject = value; }

            get { return BaseTicket.Subject; }
        }

        public String Body
        {
            private set { BaseTicket.Comment.Body = value; }

            get { return BaseTicket.Comment.Body; }
        }

        public String[] Tags
        {
            private set { BaseTicket.Tags = value.ToList(); }

            get { return BaseTicket.Tags.ToArray(); }
        }
    }
}
