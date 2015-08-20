using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LearnNHibernate.Domain;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace LearnNHibernate
{
    public class Repository
    {
        public Configuration Configuration { private set; get; }

        public Repository()
        {
            Configuration = new Configuration();

            Configuration.AddAssembly(Assembly.GetExecutingAssembly());
        }

        protected ISession GetSession(Boolean open = true)
        {
            var sessionFactory = Configuration.BuildSessionFactory();

            return sessionFactory.OpenSession();
        }

        protected ResultType Try<ResultType>(Func<ISession, ResultType> function)
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

        protected T Save<T>(ISession session, T item)
            where T : Base
        {
            session.Save(item);

            return item;
        }

        protected IEnumerable<T> GetAll<T>()
            where T : Base
        {
            return Try(session => session.CreateCriteria<T>().List<T>());
        }

        #region Customer

        public Customer AddCustomer(String name)
        {
            var customer = new Customer
            {
                Name = name,
            };

            return Try(session => Save(session, customer));
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return GetAll<Customer>();
        }

        #endregion

        #region Order

        public Order AddOrder(Decimal cost, String productName, Customer customer)
        {
            var order = new Order
            {
                Cost = cost,
                ProductName = productName,
                SaleDateAndTime = GetCurrentDateTime(),
                Customer = customer,
            };

            return Try(session => Save(session,  order));
        }

        public IEnumerable<Order> GetOrders()
        {
            return GetAll<Order>();
        }

        public IEnumerable<Order> GetCustomerOrders(Customer customer)
        {
            throw new NotImplementedException();
        }

        #endregion

        public static DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
