using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writers.Tickets.Zendesk.Sample
{
    public static class Program
    {
        public static readonly IWindsorContainer DependencyInjection;

        static Program()
        {
            DependencyInjection = new WindsorContainer();

            DependencyInjection.Register(Component.For<ITicketsRepository>().ImplementedBy<ZendeskConsoleRepository>());

            DependencyInjection.Register(Component.For<ITicket>().ImplementedBy<ZendeskTicket>());

            DependencyInjection.Register(Component.For<ITicketDestination>().ImplementedBy<ZendeskConsoleProject>());
        }

        private static void Main()
        {
            var url = Console.ReadLine();
            var login = Console.ReadLine();
            var password = Console.ReadLine();

            var repository = new ZendeskRepository(new ZendeskProject(url, login, password));

            Console.WriteLine("Connection: {0}", repository.ZendeskProject.CheckConnection());

            var ticket = new ZendeskTicket
            {
                Subject = "Automatically created ticket " + DateTime.Now,
                Body = "This ticket was created by robot",
                Tags = new[] { "Unique_key_of_ticket" },
                Priority = ZendeskTicketPriorities.Normal,
            };

            Console.WriteLine("Created: {0}", repository.Create(ticket));

            Console.ReadLine();

            DependencyInjection.Dispose();
        }
    }
}
