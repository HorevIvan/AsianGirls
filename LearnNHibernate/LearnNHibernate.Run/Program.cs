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
            (new Repository()).Run();
        }
    }
}
