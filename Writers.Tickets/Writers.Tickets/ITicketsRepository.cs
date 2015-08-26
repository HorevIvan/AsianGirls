using System;

namespace Writers.Tickets
{
    public interface ITicketsRepository
    {
        ITicketDestination TicketDestination { get; }

        String Create(ITicket ticket);

        void Update(ITicket ticket);
    }
}
