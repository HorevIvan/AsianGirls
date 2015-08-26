﻿using System;
using System.Linq;
using ZendeskApi_v2.Models.Tickets;

namespace Writers.Tickets.Zendesk
{
    public static class ZendeskHelpers
    {
        public static Ticket ToJsonTicket(this ITicket<Int64?> ticket)
        {
            return new Ticket
            {
                Subject = ticket.Subject,
                Id = ticket.Identifier,
                Comment = new Comment { Body = ticket.Body},
                Tags = ticket.Tags.ToList(),
                Priority = ticket.Priority,
            };
        }

        public static ZendeskTicket ToZendeskTicket(this Ticket ticket)
        {
            return new ZendeskTicket
            {
                Subject = ticket.Subject,
                Identifier = ticket.Id,
                Body = ticket.Comment.Body,
                Tags = ticket.Tags.ToArray(),
                Priority = ticket.Priority,
            };
        }
    }
}
