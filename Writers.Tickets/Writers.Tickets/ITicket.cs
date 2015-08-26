using System;

namespace Writers.Tickets
{
    public interface ITicket
    {
        String Identifier { get; }

        String Subject { get; }

        String Body { get; }

        String[] Tags { get; }

        String Priority { get; }
    }
}
