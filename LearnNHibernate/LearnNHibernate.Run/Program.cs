using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNHibernate.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository();

            repository.AddCustomer(DateTime.Now.Ticks.ToString());

            repository.GetCustomers().ForEach(PrintCustomer);

            Console.ReadLine();
        }

        private static void PrintCustomer(Customer customer)
        {
            Console.WriteLine("{0}\t{1}", customer.Number, customer.Name);
        }
    }

    internal static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            collection.ToList().ForEach(action);
        }
    }
}
