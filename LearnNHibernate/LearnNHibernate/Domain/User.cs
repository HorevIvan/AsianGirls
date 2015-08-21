using System;
using System.Text;
using System.Collections.Generic;
using LearnNHibernate.Domain;


namespace LearnNHibernate
{
    public class User : Base
    {
        public virtual String Name { set; get; }

        public virtual Int32 UserTypeNumber { protected set; get; }

        public virtual IEnumerable<Order> Orders { set; get; }

        #region UserType

        public virtual void SetUserType(UserType userType)
        {
            UserTypeNumber = (Int32)userType;
        }

        public virtual UserType GetUserType()
        {
            return (UserType)UserTypeNumber;
        }

        #endregion

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
    public class UserTypeItem : Base
    {
        public virtual Int32 Number { set; get; }

        public virtual String Name { set; get; }
    }
}
