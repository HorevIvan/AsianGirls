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
            var repository = DependencyInjection.Resolve<ITicketsRepository>();

            Console.WriteLine("Connection: {0}", repository.TicketDestination.CheckConnection());

            var ticket = DependencyInjection.Resolve<ITicket>();
            ticket.Subject = "Automatically created ticket " + DateTime.Now;
            ticket.Body = "This ticket was created by robot";
            ticket.Tags = new[] { "Unique_key_of_ticket" };
            ticket.Priority = ZendeskTicketPriorities.Normal;

            Console.WriteLine("Created: {0}", repository.Create(ticket));

            Console.WriteLine("Program is terminated");

            Console.ReadLine();

            DependencyInjection.Dispose();
        }
    }
}