using System;
using System.Text;
using System.Collections.Generic;
using LearnNHibernate.Domain;


namespace LearnNHibernate
{
    public class Order : Base
    {
        public virtual User User { get; set; }

        public virtual Decimal Cost { get; set; }

        public virtual String ProductName { get; set; }

        public virtual DateTime SaleDateAndTime { get; set; }
    }
}
