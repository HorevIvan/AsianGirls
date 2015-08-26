using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Writers.Tickets
{
    public interface IRepository<TID>
    {
        TID Create(ITicket<TID> ticket);

        void Update(ITicket<TID> ticket);
    }
}
