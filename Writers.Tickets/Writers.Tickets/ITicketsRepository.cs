using System;

namespace Writers.Tickets
{
    public interface ITicketsRepository<TID>
    {
        TID Create(ITicket<TID> ticket);

        void Update(ITicket<TID> ticket);
    }
}
