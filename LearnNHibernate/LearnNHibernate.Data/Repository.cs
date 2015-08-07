using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

        protected T Save<T>(ISession session, Func<T> constructor)
        {
            var item = constructor();

            session.Save(item);

            return item;
        }

        #region Customer

        public Customer AddCustomer(String name)
        {
            return Try((session) => Save(session, () => new Customer { Name = name }));
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return Try((session) => session.CreateCriteria<Customer>().List<Customer>());
        }

        #endregion
    }
}
