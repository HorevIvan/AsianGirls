using System;
using TIdentifier = System.Nullable<System.Int64>;

namespace Writers.Tickets.Zendesk
{
    public class ZendeskRepository : ITicketsRepository<TIdentifier>
    {
        public ZendeskProject ZendeskProject { private set; get; }

        public ZendeskRepository(ZendeskProject zendeskProject)
        {
            ZendeskProject = zendeskProject;
        }

        public ITicketDestination TicketDestination
        {
            get { return ZendeskProject; }
        }

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
