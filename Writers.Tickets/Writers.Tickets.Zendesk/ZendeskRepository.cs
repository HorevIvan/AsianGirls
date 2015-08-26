using System;
using ZendeskApi_v2.Models.Constants;
using ZendeskApi_v2.Models.Tickets;

namespace Writers.Tickets.Zendesk
{
    public class ZendeskRepository : ITicketsRepository
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

        public String Create(ITicket ticket)
        {
            var api = ZendeskProject.GetApi();

            var jsonTicket = ticket.ToJsonTicket();

            var ticketResponse = api.Tickets.CreateTicket(jsonTicket);

            return ticketResponse.Ticket.Id.ToString();
        }

        public void Update(ITicket ticket)
        {
            var api = ZendeskProject.GetApi();

            var jsonTicket = ticket.ToJsonTicket();

            var ticketResponse = api.Tickets.UpdateTicket(jsonTicket);
        }
    }
}
