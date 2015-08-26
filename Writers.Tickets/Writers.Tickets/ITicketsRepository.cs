using System;

namespace Writers.Tickets
{
    public interface ITicketsRepository<TID>
    {
        ITicketDestination TicketDestination { get; }

        TID Create(ITicket<TID> ticket);

        void Update(ITicket<TID> ticket);
    }
}
