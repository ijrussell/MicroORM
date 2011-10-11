using System;
using System.Dynamic;

namespace NxtGenUG_MicroORM.SimpleDataDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleQuery();
            FilteredQuery();
            Crud();
            SelectProcedure();
            //PagedQuery();

            Console.ReadLine();
        }

        private static void ComplexQuery()
        {
            //db.Posts.All().Having(db.Posts.Comments.CommentId.Count() == 0);

        }

        private static void Crud()
        {
            var service = new SimpleDataDynamicServices();

            dynamic customer = new ExpandoObject();

            customer.FirstName = "Ian";
            customer.LastName = "Russell";
            customer.Email = "i.j.russell@tesco.net";

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
            var service = new SimpleDataDynamicServices();

            var customers = service.GetCustomersFromCountry("United Kingdom");

            foreach (var customer in customers)
                ObjectDumper.Write(customer);
        }

        private static void PagedQuery()
        {
            var service = new SimpleDataDynamicServices();

            var result = service.GetCustomers(2);

            foreach (dynamic customer in result.Items)
                ObjectDumper.Write(customer);

            ObjectDumper.Write(string.Format("There are {0} records matching the criteria", result.TotalRecords));
        }

        private static void SimpleQuery()
        {
            var service = new SimpleDataDynamicServices();

            var customers = service.GetCustomers();

            foreach (var customer in customers)
                ObjectDumper.Write(customer);
        }

        private static void SelectProcedure()
        {
            var service = new SimpleDataDynamicServices();

            var sales = service.GetSalesSummary(2011);

            foreach (var item in sales)
                ObjectDumper.Write(item);
        }
    }
}
