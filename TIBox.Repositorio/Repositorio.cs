using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace TIBox.Repositorio
{
    public class Repositorio : IRepositorio
    {
        private readonly string _conecctionString;

        public Repositorio()
        {
            _conecctionString = ConfigurationManager
                .ConnectionStrings["NorthwindConnectionString"]
                .ConnectionString;
        }
        public bool DeleteCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                return connection.Delete(customer);
            }            
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                return connection.GetAll<Customer>();
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                return connection.Get<Customer>(id);
            }
        }

        public int InsertCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                return (int)connection.Insert(customer);
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                return connection.Update(customer);
            }
        }
    }
}
