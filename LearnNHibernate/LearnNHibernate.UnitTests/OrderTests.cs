using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnNHibernate.UnitTests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void AddOrderTest()
        {
            var repository = new Repository();

            var customer = repository.AddCustomer("customer1");

            var cost = (Decimal)(100 + DateTime.Now.Second + .50);

            var productName = "ProductName";

            var time1 = Repository.GetCurrentDateTime();

            var order1 = repository.AddOrder(cost, productName, customer);

            (order1.Number > 0).TEST();

            (order1.Cost - cost < (Decimal)0.0001).TEST();

            (order1.ProductName == productName).TEST();
        }
    }
}
