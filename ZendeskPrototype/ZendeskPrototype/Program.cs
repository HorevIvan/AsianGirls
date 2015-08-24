using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZendeskApi_v2;
using ZendeskApi_v2.Models.Constants;
using ZendeskApi_v2.Models.Tickets;

namespace ZendeskPrototype
{
    class Program
    {
        static void Main()
        {
            var api = GetApi();

            DisplayViews(api);

            Console.ReadLine();
        }

        private static ZendeskApi GetApi()
        {
            Console.WriteLine("Enter path");

            var path = Console.ReadLine();

            Console.WriteLine("Enter email");

            var email = Console.ReadLine();

            Console.WriteLine("Enter password");

            var password = Console.ReadLine();

            return CreateApi(path + "/api/v2", email, password);
        }

        private static ZendeskApi CreateApi(String path, String email, String password)
        {
            Console.WriteLine("--Api-----");

            return new ZendeskApi(path, email, password);
        }

        private static void DisplayViews(ZendeskApi api)
        {
            Console.WriteLine("--Views-----");

            var views = api.Views.GetAllViews().Views;

            foreach (var view in views)
            {
                Console.Write(view.Id);

                Console.Write("\t");

                Console.Write(view.Title);

                Console.WriteLine();
            }
        }
    }
}
