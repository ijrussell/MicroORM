using System.Collections.Generic;
using Simple.Data;

namespace NxtGenUG_MicroORM.SimpleData
{
    public class SimpleDataServices
    {
        private dynamic db;
        
        public SimpleDataServices()
        {
            db = Database.OpenNamedConnection("Chinook");
        }
        
        public IEnumerable<Customer> GetCustomers()
        {
            return db.Customer.All().Cast<Customer>();
        }

        public IEnumerable<Customer> GetCustomers(int pageNumber, byte pageSize = 10)
        {
            var pageStart = (pageNumber - 1) * pageSize;
            
            return db.Customer.All()
                     .Skip(pageStart).Take(pageSize)
                     .OrderByCustomerId()
                     .Cast<Customer>();
        }

        public IEnumerable<Customer> GetCustomersFromCountry(string countryName)
        {
            return db.Customer.FindAllByCountry("United Kingdom").Cast<Customer>();
        }

        public Customer Get(long id)
        {
            return (Customer)db.Customer.FindByCustomerId(id);
        }

        public Customer Insert(Customer customer)
        {
            return (Customer)db.Customer.Insert(customer);
        }

        public void Update(Customer customer)
        {
            db.Customer.UpdateByCustomerId(customer);
        }

        public void Delete(Customer customer)
        {
            db.Customer.DeleteByCustomerId(customer.CustomerId);
        }

        public IEnumerable<SalesSummaryView> GetSalesSummary(int year)
        {
            return db.SalesSummary(year).Cast<SalesSummaryView>();
        }
    }
}
