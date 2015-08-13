using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnNHibernate.UnitTests
{
    public static class TestExtensions
    {
        public static void TEST(this Boolean term, String message = null)
        {
            Assert.IsTrue(term, message);
        }
    }
}
