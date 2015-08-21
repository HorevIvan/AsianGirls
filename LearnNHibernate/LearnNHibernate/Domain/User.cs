using System;
using System.Text;
using System.Collections.Generic;
using LearnNHibernate.Domain;


namespace LearnNHibernate
{
    public class User : Base
    {
        public virtual String Name { get; set; }

        protected virtual Int32 UserTypeNumber { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }

        public virtual UserType Type
        {
            set { UserTypeNumber = (Int32)value; }

            get { return (UserType)UserTypeNumber; }
        }
    }

    public enum UserType
    {
        Customer,

        Support,

        Writer,

        System,
    }
}


namespace LearnNHibernate.Service
{
    public class UserTypeItem
    {
        public virtual Int32 Number { set; get; }

        public virtual String Name { set; get; }
    }
}
