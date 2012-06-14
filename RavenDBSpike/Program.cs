using System;

namespace RavenDBSpike
{
    class Program
    {
        static void Main()
        {
            CustomerDocument queriedCustomer;
            
            var id = Guid.NewGuid();
            var customer = new CustomerDocument
                               {
                                   Id = id, FirstName = "Darth", LastName = "Vader"
                               };

            Console.WriteLine("Fire up RavenDB...");
            var raven = new RavenFactory().GetStore();

            using (var session = raven.OpenSession())
            {
                session.Store(customer);
                session.SaveChanges();
            }

            using (var session = raven.OpenSession())
            {
                queriedCustomer = session.Load<CustomerDocument>(id);
            }

            Console.WriteLine("Original Customer:      {0} {1} {2}", customer.Id,customer.FirstName,customer.LastName);
            Console.WriteLine("Retrieved From RavenDB: {0} {1} {2}", queriedCustomer.Id, queriedCustomer.FirstName, queriedCustomer.LastName);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press the any key to continue...");
            Console.ReadLine();
        }
    }
}
