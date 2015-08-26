using System;

namespace Writers.Tickets
{
    public class TicketBase<TIdentifier> : ITicket<TIdentifier>
    {
        public TIdentifier Identifier { set; get; }

        public String Subject { set; get; }

        public String Body { set; get; }

        public String[] Tags { set; get; }

        public String Priority { set; get; }
    }
}