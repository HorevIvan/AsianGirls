using System;
using System.Text;
using System.Collections.Generic;


namespace LearnNHibernate
{
    public class Customer {
        public virtual int Number { get; set; }
        public virtual string Name { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }  
    }
}
