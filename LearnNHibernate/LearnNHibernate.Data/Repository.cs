using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LearnNHibernate.Domain;
using LearnNHibernate.Service;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Transform;

namespace LearnNHibernate
{
    public class Repository
    {
        public Configuration Configuration { private set; get; }

        public ReadOnlyDictionary<UserType, UserTypeItem> UserTypes { private set; get; }

        public Repository()
        {
            Configuration = new Configuration();

            Configuration.AddAssembly(Assembly.GetExecutingAssembly());

            UserTypes = CheckUserTypes();
        }

        #region Common

        protected ISession GetSession(Boolean open = true)
        {
            var sessionFactory = Configuration.BuildSessionFactory();

            return sessionFactory.OpenSession();
        }

        public ResultType Try<ResultType>(Func<ISession, ResultType> function)
        {
            using (var session = GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var result = function(session);

                        transaction.Commit();

                        return result;
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();

                        //TODO log exception

                        throw;
                    }
                }
            }
        }

        protected ItemType Save<ItemType>(ISession session, ItemType item)
        {
            session.Save(item);

            return item;
        }

        protected IEnumerable<T> GetAll<T>()
            where T : class
        {
            return Try(session => session.CreateCriteria<T>().List<T>());
        }

        public static DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        protected Int32 ClearTable<T>()
            where T : class
        {
            var items = GetAll<T>();

            return Try(session =>
            {
                foreach (var item in items)
                {
                    session.Delete(item);
                }

                return items.Count();
            });
        }

        #endregion


        #region User

        public User AddUser(String name, UserType type)
        {
            var user = new User
            {
                Name = name,
                Type =  type,
            };

            return Try(session => Save(session, user));
        }

        public IEnumerable<User> GetUsers()
        {
            return GetAll<User>();
        }

        #endregion

        #region Order

        public Order AddOrder(Int32 cost, String productName, User user)
        {
            var order = new Order
            {
                Cost = cost,
                ProductName = productName,
                SaleDateAndTime = GetCurrentDateTime(),
                User = user,
            };

            return Try(session => Save(session,  order));
        }

        public IEnumerable<Order> GetOrders()
        {
            return GetAll<Order>();
        }

        public IEnumerable<Order> GetCustomerOrders(User user)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region UserTypeItem

        protected UserTypeItem AddUserTypeItem(Int32 number, String name)
        {
            var userType = new UserTypeItem
            {
                Number = number,
                Name = name,
            };

            return Try(session => Save(session, userType));
        }

        protected UserTypeItem CheckExistanceUserType(UserType userType)
        {
            var userTypeData = GetUserTypeItem(userType);

            if (userTypeData == null)
            {
                var name = Enum.GetName(typeof(UserType), userType);

                userTypeData = AddUserTypeItem((Int32)userType, name);
            }

            return userTypeData;
        }

        protected ReadOnlyDictionary<UserType, UserTypeItem> CheckUserTypes()
        {
            var userTypes = new Dictionary<UserType, UserTypeItem>();

            foreach (var userType in Tools.GetEnumValues<UserType>())
            {
                userTypes[userType] = CheckExistanceUserType(userType);
            }

            return new ReadOnlyDictionary<UserType, UserTypeItem>(userTypes);
        }

        protected UserTypeItem GetUserTypeItem(UserType userType)
        {
            return 
                Try(session => session
                    .CreateCriteria<UserTypeItem>()
                    .Add(Restrictions.Eq("Number", (Int32)userType))
                    .SetMaxResults(1)
                    .List<UserTypeItem>()
                    .SingleOrDefault());
        }

        #endregion

        #region Queries

        public IEnumerable<Order> GetOrdersByUserType(UserType userType)
        {
            return 
                Try(session => session
                    .QueryOver<Order>()
                    .JoinQueryOver(o => o.User)
                    .Where(u => u.UserTypeNumber == (Int32)userType)
                    .List<Order>());
        }

        #endregion
    }
}
