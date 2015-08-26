using System;
using ZendeskApi_v2.Models.Constants;
using ZendeskApi_v2.Models.Tickets;
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
            var api = ZendeskProject.GetApi();

            var jsonTicket = ticket.ToJsonTicket();

            var ticketResponse = api.Tickets.CreateTicket(jsonTicket);

            return ticketResponse.Ticket.Id;
        }

        public void Update(ITicket<TIdentifier> ticket)
        {
            var api = ZendeskProject.GetApi();

            var jsonTicket = ticket.ToJsonTicket();

            var ticketResponse = api.Tickets.UpdateTicket(jsonTicket);
        }
    }
}
