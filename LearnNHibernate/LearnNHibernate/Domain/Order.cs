using System;
using System.Text;
using System.Collections.Generic;


namespace LearnNHibernate
{
    public class Order {
        public virtual int Number { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual string ProductName { get; set; }
        public virtual DateTime SaleDateAndTime { get; set; }
    }
}
