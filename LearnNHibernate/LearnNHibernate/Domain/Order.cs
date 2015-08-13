using System;
using System.Text;
using System.Collections.Generic;
using LearnNHibernate.Domain;


namespace LearnNHibernate
{
    public class Order : Base
    {
        public virtual Customer Customer { get; set; }

        public virtual decimal Cost { get; set; }

        public virtual string ProductName { get; set; }

        public virtual DateTime SaleDateAndTime { get; set; }
    }
}
