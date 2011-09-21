using System;

namespace NxtGenUG_MicroORM.SimpleData
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleQuery();
            PagedQuery();
            FilteredQuery();
            Crud();
            SelectProcedure();

            Console.ReadLine();
        }

        private static void Crud()
        {
            var service = new SimpleDataServices();

            var customer = new Customer
            {
                FirstName = "Ian",
                LastName = "Russell",
                Email = "i.j.russell@tesco.net"
            };

            customer = service.Insert(customer);

            ObjectDumper.Write(customer);

            customer.Country = "United Kingdom";

            service.Update(customer);

            customer = service.Get(customer.CustomerId);

            ObjectDumper.Write(customer);

            service.Delete(customer);

            customer = service.Get(customer.CustomerId);

            ObjectDumper.Write(customer);
        }

        private static void FilteredQuery()
        {
            var service = new SimpleDataServices();

            var customers = service.GetCustomersFromCountry("United Kingdom");

            foreach (var customer in customers)
                ObjectDumper.Write(customer);
        }

        private static void PagedQuery()
        {
            var service = new SimpleDataServices();

            var customers = service.GetCustomers(2);

            foreach (var customer in customers)
                ObjectDumper.Write(customer);
        }

        private static void SimpleQuery()
        {
            var service = new SimpleDataServices();

            var customers = service.GetCustomers();

            foreach (var customer in customers)
                ObjectDumper.Write(customer);
        }

        private static void SelectProcedure()
        {
            var service = new SimpleDataServices();

            var sales = service.GetSalesSummary(2011);

            foreach (var item in sales)
                ObjectDumper.Write(item);
        }
    }
}
