using System;

namespace Writers.Tickets
{
    public interface ITicketsService
    {
        ITicketDestination TicketDestination { get; }

        Int64 CreateTicket(String subject, String message, String priority, String tag);

        void UpdateTicketPriority(Int64 identifier, String priority);
    }
}
