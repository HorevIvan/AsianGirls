using System;

namespace Writers.Tickets
{
    public interface ITicketsRepository<TIdentifier>
    {
        ITicketDestination TicketDestination { get; }

        TIdentifier Create(ITicket<TIdentifier> ticket);

        void Update(ITicket<TIdentifier> ticket);
    }
}
