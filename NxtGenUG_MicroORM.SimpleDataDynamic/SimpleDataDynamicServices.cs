using System.Collections.Generic;
using Simple.Data;

namespace NxtGenUG_MicroORM.SimpleDataDynamic
{
    public class SimpleDataDynamicServices
    {
        private dynamic db;

        public SimpleDataDynamicServices()
        {
            db = Database.OpenNamedConnection("Chinook");
        }

        public IEnumerable<dynamic> GetCustomers()
        {
            return db.Customer.All();
        }

        public IEnumerable<dynamic> GetCustomers(int pageNumber, byte pageSize = 10)
        {
            var pageStart = (pageNumber - 1) * pageSize;

            return db.Customer.All().Skip(pageStart).Take(pageSize).OrderByCustomerId();
        }

        public IEnumerable<dynamic> GetCustomersFromCountry(string countryName)
        {
            return db.Customer.FindAllByCountry("United Kingdom");
        }

        public dynamic Get(long id)
        {
            return db.Customer.FindByCustomerId(id);
        }

        public dynamic Insert(dynamic customer)
        {
            return db.Customer.Insert(customer);
        }

        public void Update(dynamic customer)
        {
            db.Customer.UpdateByCustomerId(customer);
        }

        public void Delete(dynamic customer)
        {
            db.Customer.DeleteByCustomerId(customer.CustomerId);
        }

        public IEnumerable<dynamic> GetSalesSummary(int year)
        {
            return db.SalesSummary(year);
        }
    }
}
