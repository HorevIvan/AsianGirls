using System;
using TID = System.Nullable<System.Int64>;

namespace Writers.Tickets.Zendesk
{
    public class ZendeskRepository : ITicketsRepository<TID>
    {
        public ITicketDestination TicketDestination { get; private set; }

        public TID Create(ITicket<TID> ticket)
        {
            throw new NotImplementedException();
        }

        public void Update(ITicket<TID> ticket)
        {
            throw new NotImplementedException();
        }
    }
}
