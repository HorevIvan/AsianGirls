﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnNHibernate.Domain;
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

            var user = repository.AddUser("User Name", UserType.System);

            var cost = (Decimal)(100 + DateTime.Now.Second + .50);

            var productName = "ProductName";

            var order = repository.AddOrder(cost, productName, user);

            (order.Number > 0).TEST();

            (order.Cost - cost < (Decimal)0.0001).TEST();

            (order.ProductName == productName).TEST();
        }
    }
}
