using System;

namespace Writers.Tickets
{
    public interface ITicket<TID>
    {
        TID Identifier { get; }

        String Subject { get; }

        String Body { get; }

        String[] Tags { get; }
    }
}
