using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZendeskApi_v2;
using ZendeskApi_v2.Models.AccountsAndActivities;
using ZendeskApi_v2.Models.Constants;
using ZendeskApi_v2.Models.Shared;
using ZendeskApi_v2.Models.Tickets;
using Settings = ZendeskPrototype.Properties.Settings;

namespace ZendeskPrototype
{
    class Program
    {
        private static readonly String SubjectStart = "Test ticket from prototype";

        private static ZendeskApi_v2.Models.Users.User CurrentUser;

        static void Main()
        {
            var api = GetApi();

            //DisplayViews(api);

            //SendTestTicket(api);

            UpdateTickets(api);

            Console.WriteLine("Complete");

            Console.ReadLine();
        }

        private static void UpdateTickets(ZendeskApi api)
        {
            var responseTickets = api.Tickets.GetAllTickets();

            var pageUrl = responseTickets.NextPage;

            var pageUrlParts = pageUrl.Split('=');

            pageUrl = pageUrlParts[0] + "=" + (Int32.Parse(pageUrlParts[1]) - 1);

            while (!String.IsNullOrEmpty(pageUrl))
            {
                Console.WriteLine("Scaning page: {0}", pageUrl);

                responseTickets = api.Tickets.GetByPageUrl<GroupTicketResponse>(pageUrl);

                var tickets = responseTickets.Tickets.Where(row => row.Subject.StartsWith(SubjectStart));

                foreach (var ticket in tickets)
                {
                    var comment = new Comment
                    {
                        AuthorId = CurrentUser.Id,
                        Body = String.Format("Updated from: {0:yyyy.MM.dd HH:mm:ss.fffff}",DateTime.Now),
                    };

                    var response = api.Tickets.UpdateTicket(ticket, comment);

                    var updatedTicket = response.Ticket;

                    Console.WriteLine("Updated: {0}\t{1}\t{2}", updatedTicket.Id, updatedTicket.Status, updatedTicket.Subject);
                }

                pageUrl = responseTickets.NextPage;
            }
        }

        private static void SendTestTicket(ZendeskApi api)
        {
            Console.WriteLine("Tickets:");

            var ticket = new Ticket()
            {
                Subject = SubjectStart + DateTime.Now.Ticks,

                Comment = new Comment()
                {
                    Body = "HELP ME!!!",
                },

                Priority = TicketPriorities.Urgent,
            };

            api.Tickets.CreateTicket(ticket);

            Console.WriteLine("Done");
        }

        private static ZendeskApi GetApi()
        {
            var useSettings = false;

            var settings = Settings.Default;

            // Load setings?
            {
                Console.WriteLine("Use settings? Y/N");

                if (Console.ReadLine().ToLower() == "y")
                {
                    useSettings = true;

                    settings.Upgrade();
                }
            }

            String path, email, password;

            Func<String, Boolean> isNeedInput = field => !useSettings || String.IsNullOrEmpty(field);

            // Path
            {
                path = settings.Path;

                if (isNeedInput(path))
                {
                    Console.WriteLine("Enter Path");

                    path = Console.ReadLine();

                    settings.Path = path;
                }
                else
                {
                    Console.WriteLine("Path: " + path);
                }
            }

            // EMail
            {
                email = settings.EMail;

                if (isNeedInput(email))
                {
                    Console.WriteLine("Enter EMail");

                    email = Console.ReadLine();

                    settings.EMail = email;
                }
                else
                {
                    Console.WriteLine("Email: " + email);
                }
            }

            // Password
            {
                password = settings.Password;

                if (isNeedInput(password))
                {
                    Console.WriteLine("Enter Password");

                    password = Console.ReadLine();

                    settings.Password = password;
                }
                else
                {
                    Console.WriteLine("Password: " + password);
                }
            }

            var api = new ZendeskApi(path + "/api/v2", email, password);

            try
            {
                Console.WriteLine("Connecting...");

                CurrentUser = api.Users.GetCurrentUser().User;

                Console.WriteLine("Hello {0}", CurrentUser.Name);

                if (useSettings)
                {
                    // save to C:\Users\<UserName>\AppData\Local\ZendeskPrototype\
                    settings.Save();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return api;
        }

        private static void DisplayViews(ZendeskApi api)
        {
            Console.WriteLine("Views:");

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
