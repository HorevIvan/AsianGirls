using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnNHibernate.UnitTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void AddCustomerTest()
        {
            var repository = new Repository();

            var name = "Name";

            var customers1 = repository.GetCustomers();

            var addedCustomer = repository.AddCustomer(name);

            (addedCustomer.Number > 0).TEST();

            (addedCustomer.Name == name).TEST();

            var customers2 = repository.GetCustomers();

            customers1.Any(c => c.Number != addedCustomer.Number).TEST();

            customers2.Any(c => c.Number == addedCustomer.Number).TEST();
        }
    }
}
