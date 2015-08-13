using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNHibernate
{
    public static class ExtensionMethods
    {
        public static Boolean Not(this Boolean value)
        {
            return !value;
        }
    }
}
