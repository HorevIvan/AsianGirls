using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Writers.Tickets.Zendesk.Sample
{
    public class ZenConsoleProject : ZenProject
    {
        public ZenConsoleProject()
            //
            : base(GetUrl(), GetUserEMail(), GetUserPassword())
        {
        }

        private static string GetUserPassword()
        {
            Console.WriteLine("Enter a Zendesk project user password");

            return Console.ReadLine();
        }

        private static string GetUserEMail()
        {
            Console.WriteLine("Enter a Zendesk project user e-mail");

            return Console.ReadLine();
        }

        private static String GetUrl()
        {
            Console.WriteLine("Enter a Zendesk project URL");

            return Console.ReadLine();
        }
    }
}
