using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNHibernate.Domain
{
    public class Base
    {
        public virtual Int32 Number { set; get; }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
