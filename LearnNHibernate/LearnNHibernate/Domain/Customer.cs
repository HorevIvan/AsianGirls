using System;
using System.Text;
using System.Collections.Generic;
using LearnNHibernate.Domain;


namespace LearnNHibernate
{
    public class Customer : Base
    {
        public virtual string Name { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
