using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnNHibernate.UnitTests
{
    [TestClass]
    public class QueriesTests : BaseTests
    {
        [TestMethod]
        public void GetOrdersByUserType()
        {
            var repository = GetRepository();

            var user1 = repository.AddUser("Customer1", UserType.Customer);
            var user2 = repository.AddUser("Customer2", UserType.Customer);
            var user3 = repository.AddUser("Customer3", UserType.Customer);
            var user4 = repository.AddUser("Customer4", UserType.Customer);
            var user5 = repository.AddUser("Customer5", UserType.Customer);
            var user6 = repository.AddUser("Writer1", UserType.Writer);
            var user7 = repository.AddUser("Support1", UserType.Support);
            var user8 = repository.AddUser("Support2", UserType.Support);

            var order21 = repository.AddOrder(10020, "Шоколад", user2);
            var order22 = repository.AddOrder(5080, "Сливки", user2);
            var order23 = repository.AddOrder(1000, "Бумага", user2);
            var order24 = repository.AddOrder(4920, "Кефир", user2);

            var order41 = repository.AddOrder(20000, "Шоколад x2", user4);
            var order42 = repository.AddOrder(5080, "Сливки", user4);
            var order43 = repository.AddOrder(7040, "Скотч", user4);
            var order44 = repository.AddOrder(8045, "Мыло", user4);
            var order45 = repository.AddOrder(10020, "Шоколад", user4);
            var order46 = repository.AddOrder(12050, "Печенье", user4);
            var order47 = repository.AddOrder(1000, "Бумага", user4);
            var order48 = repository.AddOrder(4920, "Кефир", user4);


            var order61 = repository.AddOrder(90000, "Косметика", user6);

            var customerOrders = repository.GetOrdersByUserType(UserType.Customer);

            (customerOrders.Count() == 12).TEST();

            var writerOrders = repository.GetOrdersByUserType(UserType.Writer);

            (writerOrders.Count() == 1).TEST();
        }
    }
}
