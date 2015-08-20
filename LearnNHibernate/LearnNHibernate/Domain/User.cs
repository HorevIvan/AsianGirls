using System;
using System.Text;
using System.Collections.Generic;
using LearnNHibernate.Domain;


namespace LearnNHibernate
{
    public class User : Base
    {
        public virtual String Name { get; set; }

        protected virtual String UserTypeName { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }

        public virtual UserType Type
        {
            set { UserTypeName = Enum.GetName(typeof(UserType), value); }

            get { return (UserType)Enum.Parse(typeof(UserType), UserTypeName); }
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
        public virtual String Name { set; get; }
    }
}
