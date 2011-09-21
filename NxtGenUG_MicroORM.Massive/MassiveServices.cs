﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Massive;

namespace NxtGenUG_MicroORM.Massive
{
    public class MassiveServices
    {
        private dynamic db;
        
        public MassiveServices()
        {
            db = new DynamicModel("Chinook", "Customer", "CustomerId");
        }
        
        public IEnumerable<dynamic> GetCustomers()
        {
            return db.All();
        }

        public dynamic GetCustomers(int pageNumber, byte pageSize = 10)
        {
            return db.Paged(currentPage: pageNumber);
        }

        public IEnumerable<dynamic> GetCustomersFromCountry(string countryName)
        {
            return db.All(where: "Country = @0", args: countryName);
        }

        public dynamic Get(long id)
        {
            return db.Single(id);
        }

        public long Insert(dynamic customer)
        {
            return (long)db.Insert(customer);
        }

        public void Update(dynamic customer)
        {
            db.Update(customer, customer.CustomerId);
        }

        public void Delete(dynamic customer)
        {
            db.Delete(customer.CustomerId);
        }

        public IEnumerable<dynamic> GetSalesSummary(int year)
        {
            var sql = "EXEC SalesSummary @0";

            return db.Query(sql, year);
        }
    }
}
