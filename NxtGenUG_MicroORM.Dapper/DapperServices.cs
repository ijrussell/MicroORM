using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;

namespace NxtGenUG_MicroORM.Dapper
{
    public class DapperServices
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;
        
        public IEnumerable<Customer> GetCustomers()
        {
            var sql = "SELECT * FROM Customer";
            
            using (var cn = GetOpenConnection())
            {
                return cn.Query<Customer>(sql);
            }
        }

        public IEnumerable<Customer> GetCustomers(int pageNumber, out int rowCount, byte pageSize = 10)
        {
            var sql = "SELECT COUNT(*) FROM Customer; ";
            sql += "SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY CustomerId ASC) AS Row, * FROM Customer) AS Paged ";
            var pageStart = (pageNumber - 1) * pageSize;
            sql += string.Format(" WHERE Row > {0} AND Row <={1}", pageStart, (pageStart + pageSize));

            using (var cn = GetOpenConnection())
            {
                using (var multi = cn.QueryMultiple(sql))
                {
                    rowCount = multi.Read<int>().Single();
                    return multi.Read<Customer>().ToList();
                }
            }
        }

        public IEnumerable<Customer> GetCustomersFromCountry(string countryName)
        {
            var sql = "SELECT * FROM Customer WHERE Country = @Country";

            using (var cn = GetOpenConnection())
            {
                return cn.Query<Customer>(sql, new { Country = countryName });
            }
        }

        public Customer Get(long id)
        {
            using (var cn = GetOpenConnection())
            {
                return cn.Get<Customer>(id);
            }
        }
        
        public long Insert(Customer customer)
        {
            using (var cn = GetOpenConnection())
            {
                return cn.Insert<Customer>(customer);
            }
        }

        public void Update(Customer customer)
        {
            using (var cn = GetOpenConnection())
            {
                cn.Update<Customer>(customer);
            }
        }

        public void Delete(Customer customer)
        {
            using (var cn = GetOpenConnection())
            {
                cn.Delete<Customer>(customer);
            }
        }

        public IEnumerable<SalesSummaryView> GetSalesSummary(int year)
        {
            using (var cn = GetOpenConnection())
            {
                return cn.Query<SalesSummaryView>("SalesSummary", new { Year = year}, commandType: CommandType.StoredProcedure);
            }
        }

        private static SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
