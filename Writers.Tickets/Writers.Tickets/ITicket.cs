using System;

namespace Writers.Tickets
{
    public interface ITicket
    {
        String Identifier { set; get; }

        String Subject { set; get; }

        String Body { set; get; }

        String[] Tags { set; get; }

        String Priority { set; get; }
    }
}
