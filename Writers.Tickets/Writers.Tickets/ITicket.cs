using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
