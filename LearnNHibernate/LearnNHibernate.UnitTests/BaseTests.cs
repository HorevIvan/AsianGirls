using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNHibernate.UnitTests
{
    public abstract class BaseTests
    {
        public TestRepository GetRepository()
        {
            return new TestRepository();
        }
    }
}
