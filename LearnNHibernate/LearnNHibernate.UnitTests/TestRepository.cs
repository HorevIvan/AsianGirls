using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnNHibernate.Service;

namespace LearnNHibernate.UnitTests
{
    public class TestRepository : Repository
    {
        public TestRepository()
        {
            ClearTable<Order>();
            ClearTable<User>();
            //ClearTable<UserTypeItem>();
        }
    }
}
