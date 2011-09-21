using System;

namespace NxtGenUG_MicroORM.Dapper
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
            var service = new DapperServices();

            var customer = new Customer
                               {
                                   FirstName = "Ian",
                                   LastName = "Russell",
                                   Email = "i.j.russell@tesco.net"
                               };

            var id = service.Insert(customer);

            customer = service.Get(id);

            ObjectDumper.Write(customer);

            customer.Country = "United Kingdom";

            service.Update(customer);

            customer = service.Get(id);

            ObjectDumper.Write(customer);

            service.Delete(customer);

            customer = service.Get(id);

            ObjectDumper.Write(customer);
        }

        private static void FilteredQuery()
        {
            var service = new DapperServices();

            var customers = service.GetCustomersFromCountry("United Kingdom");

            foreach (var customer in customers)
                ObjectDumper.Write(customer);
        }

        private static void PagedQuery()
        {
            var service = new DapperServices();

            var customers = service.GetCustomers(2);

            foreach (var customer in customers)
                ObjectDumper.Write(customer);
        }

        private static void SimpleQuery()
        {
            var service = new DapperServices();

            var customers = service.GetCustomers();

            foreach (var customer in customers)
                ObjectDumper.Write(customer);
        }

        private static void SelectProcedure()
        {
            var service = new DapperServices();

            var sales = service.GetSalesSummary(2011);

            foreach (var item in sales)
                ObjectDumper.Write(item);
        }
    }
}
