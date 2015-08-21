using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnNHibernate.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnNHibernate.UnitTests
{
    [TestClass]
    public class UsersTests : BaseTests
    {
        [TestMethod]
        public void AddUserTest()
        {
            var repository = new Repository();

            var name = "Name";

            var type = UserType.Customer;

            var addedUser = repository.AddUser(name, type);

            (addedUser.Number > 0).TEST();

            (addedUser.Name == name).TEST();

            (addedUser.Type == type).TEST();
        }
    }
}
