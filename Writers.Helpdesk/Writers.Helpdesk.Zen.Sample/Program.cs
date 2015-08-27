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

            DependencyInjection.Register(Component.For<IHelpdeskService>().ImplementedBy<ZenConsoleRepository>());

            DependencyInjection.Register(Component.For<IHelpdeskConnection>().ImplementedBy<ZenConsoleProject>());
        }

        private static void Main()
        {
            var repository = DependencyInjection.Resolve<IHelpdeskService>();

            Console.WriteLine("Connection: {0}", repository.TicketDestination.CheckConnection());

            var subject = "Automatically created ticket " + DateTime.Now;
            var body = "This ticket was created by robot";
            var tag = "Unique_key_of_ticket";
            var priority = ZenTicket.Priority.Normal;

            var identifier = repository.CreateTicket(subject, body, priority, tag);

            Console.WriteLine("Created: {0}", identifier);

            repository.UpdateTicketPriority(identifier, ZenTicket.Priority.Low);

            Console.WriteLine("Updated: {0}", identifier);

            Console.WriteLine("Program is terminated");

            Console.ReadLine();

            DependencyInjection.Dispose();
        }
    }
}