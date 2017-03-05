using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace TIBox.Repositorio.Northwind
{
    public class CustomerRepository : BaseRepositorio<Customer>, ICustomerRepository
    {
        public Customer CustomerWithOrders(int id)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@customerId", id);
                    using (var multiple = 
                            connection.QueryMultiple("[dbo].[CustomerWithOrders]", 
                            parameters, 
                            commandType: System.Data.CommandType.StoredProcedure))
                    {
                    var customer = multiple.Read<Customer>().Single();
                    customer.Orders = multiple.Read<Order>();
                    return customer;
                    }

            }
        }

        public Customer SearchByName(string firstName, string lastName)
        {
            using (var connection = new SqlConnection(_conecctionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@firstName", firstName);
                parameters.Add("@lastName", lastName);

                return connection
                    .QueryFirst<Customer>("[dbo].[CustomerSearchByNames]", 
                    parameters, 
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
