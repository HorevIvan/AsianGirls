﻿using System;
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

        public Int64 CreateTicket(String subject, String message, String priority, String tag)
        {
            var api = ZendeskProject.GetApi();

            var ticket = new Ticket
            {
                Subject = subject,
                Comment = new Comment { Body = message },
                Priority = priority,
                Tags = new[] { tag },
            };

            var ticketResponse = api.Tickets.CreateTicket(ticket);

            return ticketResponse.Ticket.Id.Value;
        }

        public void UpdateTicketPriority(Int64 identifier, String priority)
        {
            var api = ZendeskProject.GetApi();

            var ticket = new Ticket
            {
                Id = identifier,
                Priority = priority,
            };

            var ticketResponse = api.Tickets.UpdateTicket(ticket);
        }
    }
}
