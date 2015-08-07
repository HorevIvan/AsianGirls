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

            foreach (var customer in repository.GetCustomers())
            {
                Console.WriteLine("{0}\t{1}", customer.Number, customer.Name);
            }

            Console.ReadLine();
        }
    }
}
