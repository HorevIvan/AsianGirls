using System;

namespace Writers.Tickets
{
    public interface ITicket<TID>
    {
        TID ID { get; }

        String Subject { get; }

        String Body { get; }

        String[] Tags { get; }
    }
}
