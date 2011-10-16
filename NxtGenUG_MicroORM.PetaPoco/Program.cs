namespace NxtGenUG_MicroORMPetaPoco
{
    using System;

    using NxtGenUG_MicroORM.SimpleData;

    class Program
    {
        static void Main(string[] args)
        {
            SimpleQuery();
            FilteredQuery();
            PagedQuery();
            Crud();
            SelectProcedure();

            Console.ReadLine();
        }

        private static void SimpleQuery()
        {
            var petaPocoDb = new PetaPoco.Database("Chinook");

            foreach (var customer in petaPocoDb.Query<Customer>("SELECT * FROM customer"))
            {
                ObjectDumper.Write(customer);
            }
        }

        private static void FilteredQuery()
        {
            var petaPoco = new PetaPoco.Database("Chinook");

            var customers = petaPoco.Query<Customer>("SELECT * FROM customer WHERE Country = 'United Kingdom'");
                
            foreach (var customer in customers)
                ObjectDumper.Write(customer);
        }

        private static void PagedQuery()
        {
            var petaPoco = new PetaPoco.Database("Chinook");

            var result = petaPoco.Page<Customer>(1, 5, "SELECT * FROM customer");

            foreach (var customer in result.Items)
                ObjectDumper.Write(customer);

            ObjectDumper.Write(string.Format("There are {0} records matching the criteria", result.TotalItems));
        }

        private static void Crud()
        {
            var petaPoco = new PetaPoco.Database("Chinook");

            var customer = new Customer { FirstName = "Ian", LastName = "Russell", Email = "i.j.russell@tesco.net" };

            petaPoco.Insert(customer);

            var id = customer.CustomerId;

            customer = petaPoco.Single<Customer>(id);

            ObjectDumper.Write(customer);

            customer.Country = "United Kingdom";

            petaPoco.Update(customer);

            customer = petaPoco.Single<Customer>(id);

            ObjectDumper.Write(customer);

            petaPoco.Delete<Customer>(id);

            customer = petaPoco.SingleOrDefault<Customer>(id);

            ObjectDumper.Write(customer);
        }

        private static void SelectProcedure()
        {
            var petaPoco = new PetaPoco.Database("Chinook");

            var customers =
                petaPoco.Query<Customer>(
                    PetaPoco.Sql.Builder.Append("SELECT * FROM customer").Append("WHERE country=@0", "USA"));

            foreach (var item in customers)
                ObjectDumper.Write(item);
        }
    }
}
