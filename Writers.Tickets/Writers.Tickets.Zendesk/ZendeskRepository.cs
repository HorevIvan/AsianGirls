using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writers.Tickets.Zendesk
{
    public class ZendeskRepository : ITicketsRepository<Int32>
    {
        public Int32 Create(ITicket<Int32> ticket)
        {
            throw new NotImplementedException();
        }

        public void Update(ITicket<Int32> ticket)
        {
            throw new NotImplementedException();
        }
    }
}
