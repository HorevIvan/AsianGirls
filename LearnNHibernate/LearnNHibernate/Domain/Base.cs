using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNHibernate.Domain
{
    public class Base
    {
        public virtual int Number { set; get; }

        public override int GetHashCode()
        {
            return Number;
        }
    }
}
