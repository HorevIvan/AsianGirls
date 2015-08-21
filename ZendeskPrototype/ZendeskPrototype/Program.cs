using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZendeskApi_v2;

namespace ZendeskPrototype
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter path");

            var path = Console.ReadLine();

            Console.WriteLine("Enter email");

            var email = Console.ReadLine();

            Console.WriteLine("Enter password");

            var password = Console.ReadLine();

            var api = new ZendeskApi(path + "/api/v2", email, password);

            foreach (var view in api.Views.GetAllViews().Views)
            {
                Console.Write(view.Id);
                Console.Write("\t");
                Console.Write(view.Title);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
