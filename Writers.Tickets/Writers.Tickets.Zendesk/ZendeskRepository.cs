using System;
using TIdentifier = System.Nullable<System.Int64>;

namespace Writers.Tickets.Zendesk
{
    public class ZendeskRepository : ITicketsRepository<TIdentifier>
    {
        public ITicketDestination TicketDestination { get; private set; }

        public TIdentifier Create(ITicket<TIdentifier> ticket)
        {
            throw new NotImplementedException();
        }

        public void Update(ITicket<TIdentifier> ticket)
        {
            throw new NotImplementedException();
        }
    }
}
