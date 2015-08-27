using System;

namespace Writers.Tickets
{
    public interface ITicketDestination
    {
        Boolean CheckConnection();
    }
}