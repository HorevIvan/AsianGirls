using System;
using System.Text;
using System.Collections.Generic;
using LearnNHibernate.Domain;


namespace LearnNHibernate
{
    public class Order : Base
    {
        public virtual User User { set; get; }

        public virtual Int32 Cost { set; get; }

        public virtual String ProductName { set; get; }

        public virtual DateTime SaleDateAndTime { set; get; }
    }
}
