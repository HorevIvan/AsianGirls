using System;

namespace Writers.Tickets
{
    public interface ITicket<TIdentifier>
    {
        TIdentifier Identifier { get; }

        String Subject { get; }

        String Body { get; }

        String[] Tags { get; }
    }
}
